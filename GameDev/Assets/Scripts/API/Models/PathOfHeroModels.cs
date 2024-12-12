using System;
using UnityEngine;

[Serializable]
public class PathOfHeroAttributesOut
{
    public string playerColor;
    public string playerSprite;
    public string backgroundSprite;
    public string backgroundColor;
    public string tileSprite;
    public string tileUnPaintedColor;
    public string tilePaintedColor;
    public string paintEffectColor;
    public string destroyEffectColor;
    public string backgroundMusic;
    public int difficulty;

    public PathOfHeroAttributesOut(string playerColor, string playerSprite, string backgroundSprite, string backgroundColor, string tileSprite, string tileUnPaintedColor, string tilePaintedColor, string paintEffectColor, string destroyEffectColor, string backgroundMusic, int difficulty)
    {
        this.playerColor = playerColor;
        this.playerSprite = playerSprite;
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
    public string playerColor;
    public string playerSprite;
    public string backgroundSprite;
    public string backgroundColor;
    public string tileSprite;
    public string tileUnPaintedColor;
    public string tilePaintedColor;
    public string paintEffectColor;
    public string destroyEffectColor;
    public string backgroundMusic;
    public int difficulty;

    public PathOfHeroAttributesUpdate(string playerColor, string playerSprite, string backgroundSprite, string backgroundColor, string tileSprite, string tileUnPaintedColor, string tilePaintedColor, string paintEffectColor, string destroyEffectColor, string backgroundMusic, int difficulty)
    {
        this.playerColor = playerColor;
        this.playerSprite = playerSprite;
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
    public string playerColor;
    public string playerSprite;
    public string backgroundSprite;
    public string backgroundColor;
    public string tileSprite;
    public string tileUnPaintedColor;
    public string tilePaintedColor;
    public string paintEffectColor;
    public string destroyEffectColor;
    public string backgroundMusic;
    public int difficulty;

    public PathOfHeroAttributesCreate(string playerColor, string playerSprite, string backgroundSprite, string backgroundColor, string tileSprite, string tileUnPaintedColor, string tilePaintedColor, string paintEffectColor, string destroyEffectColor, string backgroundMusic, int difficulty)
    {
        this.playerColor = playerColor;
        this.playerSprite = playerSprite;
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
