using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject itemToDrop;
    private Vector3 dropPositionOffset;

    private void Start()
    {
        dropPositionOffset = new Vector3(0, -2, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject item = GameObject.Instantiate(itemToDrop, transform.position + dropPositionOffset, Quaternion.identity);
            item.SetActive(true);
        }
    }
}
