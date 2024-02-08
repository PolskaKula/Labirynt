using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    [SerializeField] int freez = 10;

    void Update()
    {
        Rotation();
    }

    public override void PickedUp()
    {
        GameManager.gameManager.Freez(freez);
        base.PickedUp();
    }
}
