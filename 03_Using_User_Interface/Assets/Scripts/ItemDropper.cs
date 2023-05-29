using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject itemToDrop;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && itemToDrop != null)
        {
            GameObject item = GameObject.Instantiate(itemToDrop, transform.position, new Quaternion());
            item.SetActive(true);
        }
    }
}
