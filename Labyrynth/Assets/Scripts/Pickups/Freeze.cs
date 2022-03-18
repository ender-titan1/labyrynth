using System.Collections;
using UnityEngine;

public class Freeze : Pickup
{
    [SerializeField] private float time;

    public override void PickedUp()
    {
        GameManager.Instance.FreezeTime(time);
        base.PickedUp();
    }

}
