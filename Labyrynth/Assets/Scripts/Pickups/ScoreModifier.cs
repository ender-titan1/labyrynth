using System.Collections;
using UnityEngine;

public class ScoreModifier : Pickup
{
    [SerializeField] private int change;

    public override void PickedUp()
    {
        GameManager.Instance.score += change;
        base.PickedUp();
    }
}