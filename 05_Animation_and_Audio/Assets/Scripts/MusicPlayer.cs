using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Slider volSlider;
    [SerializeField]
    private TextMeshProUGUI playButtonText;
    private AudioSource playerSource;

    // Start is called before the first frame update
    void Start()
    {
        playerSource = gameObject.GetComponent<AudioSource>();
    }

    public void OnClickPlayPause()
    {
        if(playerSource.isPlaying)
        {
            playerSource.Pause();
            playButtonText.text = "Play";
        }
        else
        {
            playerSource.Play();
            playButtonText.text = "Pause";
        }
    }

    public void OnClickStop()
    {
        playerSource.Stop();
        playButtonText.text = "Play";
    }

    public void OnVolumeChange()
    {
        playerSource.volume = volSlider.value;
    }
}
