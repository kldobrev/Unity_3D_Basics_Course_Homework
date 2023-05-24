using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float rollInput;
    private Rigidbody planeRigidBody;
    private RaycastHit hitObject;
    private const float raycastLimit = 10000f;

    // Start is called before the first frame update
    private void Start()
    {
        planeRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        rollInput = 0;

        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = -1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = 1;
        }
        if(Physics.Raycast(planeRigidBody.position, planeRigidBody.velocity, out hitObject, raycastLimit)) {
            Debug.Log("Did hit " + hitObject.collider.name);
        }
    }

    private void FixedUpdate()
    {
        planeRigidBody.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);

        // tilt the plane up/down/left/right based on arrow keys
        planeRigidBody.AddRelativeTorque(verticalInput * rotationSpeed * Vector3.right, ForceMode.Force);
        planeRigidBody.AddRelativeTorque(horizontalInput * rotationSpeed * Vector3.up, ForceMode.Force);
        planeRigidBody.AddRelativeTorque(rollInput * rotationSpeed * Vector3.back, ForceMode.Force);
    }   

}
