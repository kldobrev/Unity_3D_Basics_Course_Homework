using UnityEngine;

public class FlameGateController : MonoBehaviour
{
    public ParticleSystem leftFlame;
    public ParticleSystem rightFlame;
    private Animation movementAnimation;
    private AudioSource leftFlameAudio;
    private AudioSource rightFlameAudio;
    private const float MaxFlameVolume = 0.5f;
    private float volTransitionVal;

    void Start()
    {
        movementAnimation = GetComponent<Animation>();
        leftFlameAudio = leftFlame.gameObject.GetComponent<AudioSource>();
        rightFlameAudio = rightFlame.gameObject.GetComponent<AudioSource>();
        volTransitionVal = 0f;
    }

    void LateUpdate()
    {
        if (!leftFlame.emission.enabled && leftFlameAudio.volume == 0f)
        {
            leftFlameAudio.Stop();
            rightFlameAudio.Stop();
        }
        else if (!leftFlame.emission.enabled && leftFlameAudio.isPlaying)
        {
            LowerVolume();
        }
        else if (leftFlame.emission.enabled && leftFlameAudio.volume == 0f)
        {
            RaiseVolume();
            leftFlameAudio.Play();
            rightFlameAudio.Play();
        }
        else if (leftFlame.emission.enabled && leftFlameAudio.volume != MaxFlameVolume)
        {
            RaiseVolume();
        }

    }

    public void ToggleFlames(bool playing)
    {
        ParticleSystem.EmissionModule emission = leftFlame.emission;
        emission.enabled = playing;

        emission = rightFlame.emission;
        emission.enabled = playing;
    }

    public void ToggleGateAnimation()
    {
        if(movementAnimation.isPlaying)
        {
            movementAnimation.Stop();
        }
        else
        {
            movementAnimation.Play();
        }
    }

    private void RaiseVolume()
    {
        volTransitionVal += 0.1f * Time.deltaTime;
        float volValue = Mathf.Lerp(leftFlameAudio.volume, MaxFlameVolume, volTransitionVal);
        leftFlameAudio.volume = rightFlameAudio.volume = volValue;
        if(volTransitionVal > MaxFlameVolume)
        {
            volTransitionVal = 0f;
        }
    }

    private void LowerVolume()
    {
        volTransitionVal += 0.1f * Time.deltaTime;
        float volValue = Mathf.Lerp(leftFlameAudio.volume, 0f, volTransitionVal);
        leftFlameAudio.volume = rightFlameAudio.volume = volValue;
    }
}
