using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Deactivate the gate trigger if the gate is hit
        transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("Plane crashed! Game Over");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gate Passed!");
    }
}
