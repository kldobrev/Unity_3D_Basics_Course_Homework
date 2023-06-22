using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GatesController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gatesPool;
    [SerializeField]
    private GameObject gatePrefab;
    private int lastSpawnedGateIdx;
    private Vector3 gatePositionBoundsMin;
    private Vector3 gatePositionBoundsMax;
    private Vector3 gateRotationBoundsMin;
    private Vector3 gateRotationBoundsMax;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnedGateIdx = 1;
        gatePositionBoundsMin = new Vector3(-10f, -5f, 60f);
        gatePositionBoundsMax = new Vector3(40f, 30f, 90f);
        gateRotationBoundsMin = new Vector3(-15f, -40f, -50f);
        gateRotationBoundsMax = new Vector3(15f, 40f, 50f);
        gatesPool.ForEach(g => g.GetComponent<Gate>().ToggleFlames(true));
    }

    private GameObject GetNextInactiveGate()
    {
        GameObject nextGate = gatesPool.Find(g => !g.activeSelf);
        if (nextGate == null)
        {
            nextGate = Instantiate(gatePrefab, Vector3.zero, Quaternion.identity);
            nextGate.transform.parent = transform;
            nextGate.name = "Gate" + (lastSpawnedGateIdx + 1).ToString();
            gatesPool.Add(nextGate);
        }

        return nextGate;
    }

    private Vector3 GetRandomVectorInBounds(Vector3 boundsMin, Vector3 boundsMax)
    {
        float x = Random.Range(boundsMin.x, boundsMax.x);
        float y = Random.Range(boundsMin.y, boundsMax.y);
        float z = Random.Range(boundsMin.z, boundsMax.z);
        return new Vector3(x, y, z);
    }

    public GameObject SpawnGate()
    {
        Vector3 newGatePosition = gatesPool[lastSpawnedGateIdx].transform.position + GetRandomVectorInBounds(gatePositionBoundsMin, gatePositionBoundsMax);
        GameObject newGate = GetNextInactiveGate();
        newGate.transform.position = newGatePosition;
        newGate.transform.eulerAngles = GetRandomVectorInBounds(gateRotationBoundsMin, gateRotationBoundsMax);
        newGate.SetActive(true);
        lastSpawnedGateIdx = ++lastSpawnedGateIdx % gatesPool.Count;
        return newGate;
    }
}
