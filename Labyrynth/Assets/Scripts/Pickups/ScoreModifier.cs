using System.Collections;
using UnityEngine;

public class ScoreModifier : Pickup
{
    public override void PickedUp()
    {
        Debug.Log("Coin!");
        base.PickedUp();
    }
}