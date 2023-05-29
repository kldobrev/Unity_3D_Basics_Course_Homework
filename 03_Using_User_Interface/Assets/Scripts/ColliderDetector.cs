using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public UIController UIctrl;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GateDetector"))
        {
            // Add 10 seconds to timer on gate passed
            UIctrl.AddToTimer(10);
            UIctrl.IncrementGatesPassed();
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // End game if plane hits a gate
        UIctrl.ActivateYouDiedSplash();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit");
        }
    }
}
