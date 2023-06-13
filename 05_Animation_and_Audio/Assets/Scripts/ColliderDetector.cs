using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public UI gameUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Gate"))
        {
            gameUI.UpdateTimer();
            gameUI.UpdateGateCounter();

            UpdateFlamesAndAnimation(other);
        }
    }

    private void UpdateFlamesAndAnimation(Collider other)
    {
        other.GetComponent<FlameGateController>().ToggleFlames(false);
        other.GetComponent<FlameGateController>().ToggleGateAnimation();

        int index = other.transform.GetSiblingIndex();

        if (other.transform.parent.childCount > index + 1)
        {
            Transform nextNode = other.transform.parent.GetChild(index + 1);
            if (nextNode)
            {
                nextNode.transform.GetComponent<FlameGateController>().ToggleFlames(true);
                nextNode.transform.GetComponent<FlameGateController>().ToggleGateAnimation();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<PlayerController>().isAlive = false;
        gameUI.ShowGameOverScreenDeath();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }
}
