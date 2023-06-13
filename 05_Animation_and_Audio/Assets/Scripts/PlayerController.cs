using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardForce;
    public float verticalForce;
    public float horizontalForce;
    public float rollForce;

    private Rigidbody body;
    private AudioSource engineAudio;
    private float planeVolTransitionVal ;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        engineAudio = GetComponent<AudioSource>();
        planeVolTransitionVal = 0f;
        isAlive = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rollInput = 0;

        // Push the plane forward
        body.AddRelativeForce(Vector3.forward * forwardForce, ForceMode.Acceleration);
        
        // tilt the plane by vertically
        var input = Input.GetAxis("Vertical");
        body.AddRelativeTorque(Vector3.right * verticalForce * input, ForceMode.Acceleration);

        // tilt the plane by horizontally
        input = Input.GetAxis("Horizontal");
        body.AddRelativeTorque(Vector3.up * horizontalForce * input, ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = 1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = -1;
        }

        // roll the plane
        body.AddRelativeTorque(Vector3.forward * rollForce * rollInput, ForceMode.Acceleration);
    }

    void LateUpdate()
    {
        if(!isAlive && (engineAudio.volume > 0.1f || engineAudio.pitch > 0.1f))
        {
            planeVolTransitionVal += 0.01f * Time.deltaTime;
            engineAudio.volume = Mathf.Lerp(engineAudio.volume, 0.01f, planeVolTransitionVal);
            engineAudio.pitch = Mathf.Lerp(engineAudio.pitch, 0.2f, planeVolTransitionVal);
        }
    }
}
