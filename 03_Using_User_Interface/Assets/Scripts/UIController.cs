using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public float gameTimeLimit;
    public Slider Timer;
    public Image TimeFillerImage;
    public TMP_Text GatesPassedIndicator;
    public GameObject GameOverScreen;
    private Color[] timerColors;
    private TMP_Text gameOverText;
    private int sliderColorIdx;
    private int totalNumGates;
    private int gatesPassed;

    // Start is called before the first frame update
    void Start()
    {
        gameTimeLimit = 60f;
        Timer.value = gameTimeLimit;
        timerColors = new Color[] { Color.red, Color.yellow, Color.green };
        sliderColorIdx = 2;
        TimeFillerImage.color = timerColors[sliderColorIdx];
        totalNumGates = GameObject.FindGameObjectsWithTag("GateDetector").Length;
        gatesPassed = 0;
        gameOverText = GameOverScreen.GetComponentInChildren<TMP_Text>();
        GameOverScreen.SetActive(false);
        UpdateGatesPassedIndicator();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Timer.value -= Time.deltaTime;
        if((sliderColorIdx == 2 && Timer.value < 40) || (sliderColorIdx == 1 && Timer.value < 20))
        {
            // Change timer colour depending on time remaining
            UpdateSliderColor(sliderColorIdx - 1);
        }
        else if(Timer.value <= 0)
        {
            // End game once the time is up
            ActivateYouDiedSplash();
        }
    }

    public void AddToTimer(float timeAmt)
    {
        Timer.value += timeAmt;
        if((sliderColorIdx == 0 && Timer.value >= 20) || (sliderColorIdx == 1 && Timer.value >= 40))
        {
            // Change timer colour depending on time remaining 
            UpdateSliderColor(sliderColorIdx + 1);
        }
    }

    public void IncrementGatesPassed()
    {
        gatesPassed++;
        UpdateGatesPassedIndicator();
        if(gatesPassed == totalNumGates)
        {
            // End game if all gates are passed
            ActivatePassedSplash();
        }
    }

    public void ActivateYouDiedSplash()
    {
        ActivateGameOverSplash("YOU DIED", Color.red);
    }

    private void ActivatePassedSplash()
    {
        ActivateGameOverSplash("YOU PASSED", Color.green);
    }

    public void OnRestartGameClicked()
    {
        // Restart game on button click
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    private void UpdateSliderColor(int updVal)
    {
        sliderColorIdx = updVal;
        TimeFillerImage.color = timerColors[sliderColorIdx];
    }

    private void UpdateGatesPassedIndicator()
    {
        GatesPassedIndicator.text = gatesPassed + " / " + totalNumGates;
    }

    private void ActivateGameOverSplash(string splText, Color txtColor)
    {
        Time.timeScale = 0;
        gameOverText.text = splText;
        gameOverText.color = txtColor;
        GameOverScreen.SetActive(true);
    }

}
