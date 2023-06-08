using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem flameArc1;
    [SerializeField]
    private ParticleSystem flameArc2;
    [NonSerialized]
    public float distanceToPlayer;

    void Awake()
    {
        StopFlames();
        transform.Find("GateDetector").gameObject.SetActive(false);
    }

    public void StartFlames()
    {
        flameArc1.Play();
        flameArc2.Play();
    }

    public void StopFlames()
    {
        flameArc1.Stop();
        flameArc2.Stop();
    }

}
