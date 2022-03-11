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

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Vector3 rotationVector = new Vector3(5, 0, 0);
        transform.Rotate(rotationVector);
    }
}
