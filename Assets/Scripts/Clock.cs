using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    [SerializeField] int timeToAdd = 10;
    [SerializeField] bool time;

    void Update()
    {
        Rotation();
    }

    public override void PickedUp()
    {
        int cos = -1;
        if (time) cos = 1;
        GameManager.gameManager.AddTime(cos * timeToAdd);
        base.PickedUp();
    }
}
