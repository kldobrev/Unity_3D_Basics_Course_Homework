using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public Vector3 FallSpeed;
    private float elapsedTime;
    private float endTime;
    private const float timeLimit = 5f;

    // Start is called before the first frame update
    void Start()
    {
        FallSpeed = new Vector3(0f, -10f, 1f);
        elapsedTime = Time.deltaTime;
        endTime = elapsedTime + timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        // falling down
        transform.Translate(FallSpeed * Time.deltaTime);
        // updating time tracker on each frame
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= endTime)
        {
            Destroy(gameObject);
        }
    }
}
