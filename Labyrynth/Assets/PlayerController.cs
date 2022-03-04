using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    [SerializeField] GameObject raycastOrigin;
    [SerializeField] LayerMask mask;
    Vector3 velocity;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Move();
        SetSpeed();
    }

    private void SetSpeed()
    {
        RaycastHit[] hits = Physics.RaycastAll(raycastOrigin.transform.position, Vector3.down, 2);

        speed = 12f;

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Speed Up"))
                speed = 18f;
            else if (hit.collider.CompareTag("Slow Down"))
                speed = 6f;
            else
                speed = 12f;
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
