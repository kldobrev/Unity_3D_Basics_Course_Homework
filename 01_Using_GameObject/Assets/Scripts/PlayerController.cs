using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    public float VerticalInput;
    public float HorizontalInput;
    public float PropellerRotationSpeed;
    private GameObject propeller;

    void Start()
    {
        Speed = 30f;
        RotationSpeed = 50f;
        PropellerRotationSpeed = 750f;
        propeller = GameObject.FindGameObjectWithTag("Propeller");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Speed * Time.deltaTime * Vector3.forward);

        // tilt the plane up/down based on up/down arrow keys
        if (VerticalInput != 0)
        {
            transform.Rotate(RotationSpeed * VerticalInput * Time.deltaTime * Vector3.left);
        }
        // tilt the plane left/right based on left/right arrow keys
        if (HorizontalInput != 0)
        {
            transform.Rotate(RotationSpeed * HorizontalInput * Time.deltaTime * Vector3.up);
        }
        // tilt the plane to the side based on Q/E keys
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(RotationSpeed * Time.deltaTime * Vector3.back);
        }

        // rotate the propeller clockwise when viewed from behind
        if(propeller != null)
        {
            propeller.transform.Rotate(PropellerRotationSpeed * Time.deltaTime * Vector3.back);
        }
    }
}
