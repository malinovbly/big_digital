using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 5.0f; // Aircraft speed
    public float RotationSpeed = 1.0f; // Aircraft rotation speed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal") * RotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * Speed;

        rb.AddRelativeForce(0f, 0f, forwardForce, ForceMode.Acceleration);
        rb.AddRelativeTorque(0f, sideForce, 0f, ForceMode.Acceleration);
    }
}
