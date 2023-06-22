using System;
using UnityEngine;
using UnityEngine.Events;

public class ColliderDetector : MonoBehaviour
{
    public PlaneAudio planeAudio;
    public GatesController gatesCtrl;

    [SerializeField]
    private TransformEvent onGateTriggerPassed;
    [SerializeField]
    private UnityEvent onCollisionWithObstacle;
    private const string obstacleTag = "Obstacle";

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Gate"))
        {
            onGateTriggerPassed.Invoke(other.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(obstacleTag))
        {
            onCollisionWithObstacle.Invoke();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }


    [Serializable]
    class TransformEvent : UnityEvent<Transform>
    {
    }
}
