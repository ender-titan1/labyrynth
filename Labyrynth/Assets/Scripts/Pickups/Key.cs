using System.Collections;
using UnityEngine;

public class Key : Pickup
{
    public enum KeyColor
    {
        Red,
        Green,
        Gold
    }

    [SerializeField] private KeyColor color;

    public override void PickedUp()
    {
        GameManager.Instance.AddKey(color);
        base.PickedUp();
    }

}
