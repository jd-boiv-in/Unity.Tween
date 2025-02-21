# Unity.Tween

Simple tweening engine for Unity

## Installation

Add these dependencies to your `manifest.json`

```json
{
  "dependencies": {
    "jd.boiv.in.tween": "https://github.com/starburst997/Unity.Tween.git",
    "jd.boiv.in.extensions": "https://github.com/starburst997/Unity.Extensions.git",
    "jd.boiv.in.text": "https://github.com/starburst997/Unity.Text.git"
  }
}
```

## Usage

You need to call the main loop once somewhere

```csharp
private void Update()
{
    Tweens.Instance.Update();
}
```

The library use extensions method to add tweening functionality

```csharp
Rect.TweenAnchorPosX(200, 0.25f, Ease.QuadOut);
```

## Ease

Check this [webpage](https://easings.net/en) for visualizing them.

List of supported easing:

- Linear
- SineIn
- SineOut
- SineInOut
- SineOutIn
- QuadIn
- QuadOut
- QuadInOut
- QuadOutIn
- CubicIn
- CubicOut
- CubicInOut
- CubicOutIn
- QuartIn
- QuartOut
- QuartInOut
- QuartOutIn
- QuintIn
- QuintOut
- QuintInOut
- QuintOutIn
- ExpoIn
- ExpoOut
- ExpoInOut
- ExpoOutIn
- CircIn
- CircOut
- CircInOut
- CircOutIn
- BounceIn
- BounceOut
- BounceInOut
- BounceOutIn
- BackIn
- BackOut
- BackInOut
- BackOutIn
- ElasticIn
- ElasticOut
- ElasticInOut
- ElasticOutIn
- WarpIn
- WarpOut
- WarpInOut
- WarpOutIn

## Samples

A [sample project](https://github.com/starburst997/Unity.Tween/tree/main/Samples~/Tween%20Sample) is also available.

## TODO

- Add more examples
- Better readme