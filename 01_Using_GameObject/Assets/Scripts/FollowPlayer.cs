using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Plane;
    private Vector3 offset;
    private float timeToCatchUp;

    void Start()
    {
        offset = new Vector3(0, 3, -0.1f);
        timeToCatchUp = 0.05f;
        transform.position = new Vector3(0, 3, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 nextPosition = Plane.position + offset;
        Vector3 followPosition = Vector3.Lerp(transform.position, nextPosition, timeToCatchUp);
        transform.position = followPosition;
        transform.LookAt(Plane);
    }
}
