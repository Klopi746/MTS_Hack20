using UnityEngine;
using System;


[Serializable]
public class BallsOfFateAttributesOut
{
    public String background;
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
