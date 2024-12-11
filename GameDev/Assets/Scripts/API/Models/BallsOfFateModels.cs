using UnityEngine;
using System;


[Serializable]
public class BallsOfFateAttributesOut
{
    public string backgroundSprite;
    public string backgroundColor;
    public string platformSprite;
    public string platformColor;
    public string ballOneColor;
    public string ballOneSprite;
    public string ballTwoColor;
    public string ballTwoSprite;
    public string ballOneEffectColor;
    public string ballTwoEffectColor;
    public string backgroundMusic;
    public float speedOfGame;
}


[Serializable]
public class BallsOfFateAttributesCreate
{
    public String background;

    public BallsOfFateAttributesCreate(String background) {
        this.background = background;
    }
}


[Serializable]
public class BallsOfFateAttributesUpdate
{
    public String background;

    public BallsOfFateAttributesUpdate(String background)
    {
        this.background = background;
    }
}
