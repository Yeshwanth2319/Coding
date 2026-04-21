using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ensures these components exist on the GameObject
[RequireComponent(typeof(Rigidbody), typeof (BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private FixedJoystick joystick; // Assumes a FixedJoystick script exists
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 5f;

    private void FixedUpdate()
    {
        // Vector3.zero for Y, keeps vertical physics (gravity)
        rigidbody.linearVelocity = new Vector3(joystick.Horizontal * moveSpeed, rigidbody.linearVelocity.y, joystick.Vertical * moveSpeed);

        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.linearVelocity);
        }
    }
}