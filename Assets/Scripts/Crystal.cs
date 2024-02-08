using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Pickup
{
    void Update()
    {
        Rotation();
    }

    public override void PickedUp()
    {
        GameManager.gameManager.coins += 5;
        base.PickedUp();
    }
}
