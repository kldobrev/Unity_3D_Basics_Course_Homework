using UnityEngine;

public class PlaneAudio : MonoBehaviour
{
    public float minPitchEngine;
    private AudioSource source;

    public void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public bool LowerPitchToMin()
    {
        if (source.pitch >= minPitchEngine)
        {
            source.pitch -= Time.deltaTime;
            return true;
        }
        else
        {
            return false;
        }
    }
}
