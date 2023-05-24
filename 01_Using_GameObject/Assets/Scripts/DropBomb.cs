using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{

    public GameObject BombPrefab;
    private const float xOffset = 0f;
    private const float yOffset = -0.26f;
    private const float zOffset = -1.2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateBomb();
        }
    }

    void CreateBomb()
    {
        Vector3 bombPosition = new Vector3(xOffset, yOffset, zOffset) + transform.position;
        Instantiate(BombPrefab, bombPosition, Quaternion.identity).AddComponent<BombBehaviour>();
    }
}
