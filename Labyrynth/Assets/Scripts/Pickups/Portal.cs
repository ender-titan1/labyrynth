using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform player;
    public Transform reciever;

    private bool overlap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            overlap = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            overlap = false;
    }

    private void FixedUpdate()
    {
        if (overlap)
            Teleport();
    }

    private void Teleport()
    {
        Vector3 playerVector = player.position - transform.position;
        float dotProduct = Vector3.Dot(playerVector, transform.up);

        if (dotProduct > 0)
            player.position = reciever.position;
    }
}
