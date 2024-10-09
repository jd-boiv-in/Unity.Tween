using System.Collections.Generic;

namespace JD.Tween
{
    public struct TweenPoolStats
    {
        public int Total;
        public int Refs;
        public int MaxList;
        public int MinList;
        public int Removing;
        public int TotalLifetime;
        public int Pool;
        public int PoolList;
    }
    
    // TODO: Switch to `int` key for better performance?
    public class TweenPool<T1> where T1 : Tween, new()
    {
        private int _lifetime;
        
        private readonly Queue<T1> _pool;
        private readonly Queue<List<long>> _poolList;
        
        private readonly Dictionary<long, T1> _current;
        private readonly Dictionary<int, List<long>> _refs;
        private readonly List<T1> _toRemove;
        
        public TweenPool(int capacity)
        {
            _pool = new Queue<T1>(capacity);
            _current = new Dictionary<long, T1>(capacity);
            _refs = new Dictionary<int, List<long>>(capacity);
            _toRemove = new List<T1>(capacity / 2);
            _poolList = new Queue<List<long>>(capacity);
            
            // TODO: Should we populate pool as well here?
        }

        public TweenPoolStats GetStats()
        {
            int min = 0, max = 0;

            foreach (var list in _refs.Values)
            {
                if (list.Count < min) min = list.Count;
                else if (list.Count > max) max = list.Count;
            }
            
            return new TweenPoolStats()
            {
                Total = _current.Count,
                Refs = _refs.Count,
                MinList = min,
                MaxList = max,
                Removing = _toRemove.Count,
                TotalLifetime = _lifetime,
                Pool = _pool.Count,
                PoolList = _poolList.Count
            };
        }
        
        private List<long> GetList()
        {
            if (_poolList.Count > 0)
                return _poolList.Dequeue();

            // Won't get much more than 1-2 tweens property at the same time
            var list = new List<long>(4);
            return list;
        }

        private void ReturnList(List<long> list)
        {
            list.Clear();
            _poolList.Enqueue(list);
        }
        
        public void KillAll()
        {
            foreach (var tween in _current.Values)
                Return(tween, false, false);
            
            foreach (var list in  _refs.Values)
                ReturnList(list);
            
            _refs.Clear();
            _current.Clear();
            _toRemove.Clear();
        }

        public bool Return(int targetId, bool remove = true, bool complete = false)
        {
            if (_refs.TryGetValue(targetId, out var list))
            {
                foreach (var refId in list)
                    Return(_current[refId], remove, false, complete);
                
                ReturnList(list);
                _refs.Remove(targetId);
                return true;
            }
            
            return false;
        }
        
        public bool Return(int targetId, TweenProperty property, bool remove = true, bool complete = false)
        {
            if (_refs.TryGetValue(targetId, out var list))
            {
                var propertyId = (int) property;
                for (var i = 0; i < list.Count; i++)
                {
                    var refId = list[i];
                    if ((refId >> 32) == propertyId)
                    {
                        Return(_current[refId], remove, false, complete);
                        list.RemoveAt(i);

                        if (list.Count == 0)
                        {
                            ReturnList(list);
                            _refs.Remove(targetId);
                        }
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public bool Return(T1 tween, bool remove = true, bool removeFromList = true, bool complete = false)
        {
            if (complete) tween.Complete();
            
            // We never iterate over the list and return
            if (removeFromList)
            {
                tween.Removed = true;
                var targetId = tween.TargetId;
                if (_refs.TryGetValue(targetId, out var list))
                {
                    var propertyId = (int) tween.Property;
                    for (var i = 0; i < list.Count; i++)
                    {
                        var refId = list[i];
                        if ((refId >> 32) == propertyId)
                        {
                            list.RemoveAt(i);
                            if (list.Count == 0)
                            {
                                ReturnList(list);
                                _refs.Remove(targetId);
                            }
                            break;
                        }
                    }
                }
            }
            
            // Prevent modifying the collection while iterating, so we remove them in `Update()`
            if (remove)
            {
                // Useful for debugging
                /*if (tween.Debug)
                {
                    var a = 1;
                }*/
                
                tween.Removing = true;
                _toRemove.Add(tween);
            }
            else
            {
                tween.Clear();
                _pool.Enqueue(tween);
            }

            return true;
        }

        public bool Has(int targetId, TweenProperty property)
        {
            var propertyId = (int) property;
            var refId = ((uint) targetId | ((long) propertyId) << 32);
            if (_current.ContainsKey(refId))
                return true;
            
            return false;
        }
        
        public bool TryGet(int targetId, TweenProperty property, out T1 result)
        {
            var propertyId = (int) property;
            var refId = ((uint) targetId | ((long) propertyId) << 32);
            if (_current.TryGetValue(refId, out var tween))
            {
                // Already exists on property, so simply return it so we overwrite that tween
                if (!tween.Removed)
                {
                    tween.SoftClear();
                    tween.Removing = false;
                    result = tween;
                    return true;
                }
            }
            
            result = null;
            return false;
        }
        
        public T1 Get(int targetId, TweenProperty property)
        {
            var propertyId = (int) property;
            var refId = ((uint) targetId | ((long) propertyId) << 32);
            if (_current.TryGetValue(refId, out var tween))
            {
                // Already exists on property, so simply return it so we overwrite that tween
                if (!tween.Removed)
                {
                    tween.SoftClear();
                    tween.Removing = false;
                    return tween;
                }
            }

            _lifetime++;
            
            if (_pool.Count > 0)
                tween = _pool.Dequeue();
            else
                tween = new T1();

            tween.TargetId = targetId;
            tween.RefId = refId;
            tween.Property = property;
            _current[refId] = tween;
            
            if (!_refs.TryGetValue(targetId, out var list))
                list = _refs[targetId] = GetList();

            list.Add(refId);
            return tween;
        }
        
        public void Update(float delta)
        {
            if (_toRemove.Count > 0)
            {
                foreach (var tween in _toRemove)
                {
                    if (!tween.Removing) continue;
                    if (_current.TryGetValue(tween.RefId, out var t))
                        if (tween == t) _current.Remove(tween.RefId);
                    
                    tween.Clear();
                    _pool.Enqueue(tween);
                }
                
                _toRemove.Clear();
            }
            
            foreach (var tween in _current.Values)
                tween.Update(delta);
            
            if (_toRemove.Count > 0)
            {
                foreach (var tween in _toRemove)
                {
                    if (!tween.Removing) continue;
                    if (_current.TryGetValue(tween.RefId, out var t))
                        if (tween == t) _current.Remove(tween.RefId);
                    
                    tween.Clear();
                    _pool.Enqueue(tween);
                }
                
                _toRemove.Clear();
            }
        }
    }
}