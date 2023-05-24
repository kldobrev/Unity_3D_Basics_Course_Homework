using UnityEngine;

public class Propeller : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * 10);
    }
}
