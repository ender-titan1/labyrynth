using System.Collections;
using UnityEngine;

public class Freeze : Pickup
{
    [SerializeField] private float time;

    public override void PickedUp()
    {
        GameManager.Instance.CancelInvoke("Stopper");
        GameManager.Instance.InvokeRepeating("Stopper", time, 1);

        base.PickedUp();
    }

}
