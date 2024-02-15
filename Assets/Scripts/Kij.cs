using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyColor
{
    Red,
    Green, 
    Blue,
}

public class Kij : Pickup
{
    public KeyColor color;

    public override void PickedUp()
    {
        GameManager.gameManager.AddKey(color);
        base.PickedUp();
    }
}
