using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void PickedUp()
    {
        Debug.Log("Picked Up!");
        Destroy(gameObject);
    }
}
