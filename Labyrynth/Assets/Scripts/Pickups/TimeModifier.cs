using System.Collections;
using UnityEngine;

public class TimeModifier : Pickup
{
    [SerializeField] private int change;

    public override void PickedUp()
    {
        GameManager.Instance.TimeToEnd += change;
        base.PickedUp();
    }
}
