using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    private Transform planePos;
    private List <GateController> gates;
    private int currentGateIdx;

    // Start is called before the first frame update
    void Start()
    {
        gates = new List<GateController>();
        planePos = GameObject.FindGameObjectWithTag("Player").transform;
        foreach (GameObject gate in GameObject.FindGameObjectsWithTag("FlameGate"))
        {
            gates.Add(gate.GetComponent<GateController>());
            gates.Last().distanceToPlayer = UnityEngine.Vector3.Distance(gate.transform.position, planePos.position);
        }
        BubbleSortGatesByDistance();   // Making sure the gates are ordered according to the distance from the plane
        currentGateIdx = -1;
        UpdateCurrentPrevGates();
    }

    private void BubbleSortGatesByDistance()
    {
        GateController temp;
        for(int i =  0; i < gates.Count; i++)
        {
            for(int j = 0; j < gates.Count - 1; j++)
            {
                if (gates[j].distanceToPlayer > gates[j + 1].distanceToPlayer)
                {
                    temp = gates[j];
                    gates[j] = gates[j + 1];
                    gates[j + 1] = temp; 
                }
            }
        }
    }

    public void UpdateCurrentPrevGates()
    {
        currentGateIdx++;
        if(currentGateIdx > 0)
        {
            gates[currentGateIdx - 1].StopFlames();
        }
        if(currentGateIdx != gates.Count)
        {
            gates[currentGateIdx].transform.Find("GateDetector").gameObject.SetActive(true);
            gates[currentGateIdx].StartFlames();
        }
    }

}
