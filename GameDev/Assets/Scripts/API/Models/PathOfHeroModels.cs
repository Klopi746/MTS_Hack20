using System;
using UnityEngine;

[Serializable]
public class PathOfHeroAttributesOut
{
    public string backgroundSprite;
    public string backgroundColor;
    public string tileSprite;
    public string tileUnPaintedColor;
    public string tilePaintedColor;
    public string paintEffectColor;
    public string destroyEffectColor;
    public string backgroundMusic;
    public int difficulty;

    public PathOfHeroAttributesOut(string backgroundSprite, string backgroundColor, string tileSprite, string tileUnPaintedColor, string tilePaintedColor, string paintEffectColor, string destroyEffectColor, string backgroundMusic, int difficulty)
    {
        this.backgroundSprite = backgroundSprite;
        this.backgroundColor = backgroundColor;
        this.tileSprite = tileSprite;
        this.tileUnPaintedColor = tilePaintedColor;
        this.tilePaintedColor = tilePaintedColor;
        this.paintEffectColor = paintEffectColor;
        this.destroyEffectColor = destroyEffectColor;
        this.backgroundMusic = backgroundMusic;
        this.difficulty = difficulty;
    }
}

[Serializable]
public class PathOfHeroAttributesUpdate
{
    public string backgroundSprite;
    public string backgroundColor;
    public string tileSprite;
    public string tileUnPaintedColor;
    public string tilePaintedColor;
    public string paintEffectColor;
    public string destroyEffectColor;
    public string backgroundMusic;
    public int difficulty;

    public PathOfHeroAttributesUpdate(string backgroundSprite, string backgroundColor, string tileSprite, string tileUnPaintedColor, string tilePaintedColor, string paintEffectColor, string destroyEffectColor, string backgroundMusic, int difficulty)
    {
        this.backgroundSprite = backgroundSprite;
        this.backgroundColor = backgroundColor;
        this.tileSprite = tileSprite;
        this.tileUnPaintedColor = tilePaintedColor;
        this.tilePaintedColor = tilePaintedColor;
        this.paintEffectColor = paintEffectColor;
        this.destroyEffectColor = destroyEffectColor;
        this.backgroundMusic = backgroundMusic;
        this.difficulty = difficulty;
    }
}


[Serializable]
public class PathOfHeroAttributesCreate
{
    public string backgroundSprite;
    public string backgroundColor;
    public string tileSprite;
    public string tileUnPaintedColor;
    public string tilePaintedColor;
    public string paintEffectColor;
    public string destroyEffectColor;
    public string backgroundMusic;
    public int difficulty;

    public PathOfHeroAttributesCreate(string backgroundSprite, string backgroundColor, string tileSprite, string tileUnPaintedColor, string tilePaintedColor, string paintEffectColor, string destroyEffectColor, string backgroundMusic, int difficulty)
    {
        this.backgroundSprite = backgroundSprite;
        this.backgroundColor = backgroundColor;
        this.tileSprite = tileSprite;
        this.tileUnPaintedColor = tilePaintedColor;
        this.tilePaintedColor = tilePaintedColor;
        this.paintEffectColor = paintEffectColor;
        this.destroyEffectColor = destroyEffectColor;
        this.backgroundMusic = backgroundMusic;
        this.difficulty = difficulty;
    }
}
