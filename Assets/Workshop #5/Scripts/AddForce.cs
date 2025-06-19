using UnityEngine;

public class AddForce : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 300f, ForceMode.Force);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-10f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(10f, 0, 0);
        }
    }
}
