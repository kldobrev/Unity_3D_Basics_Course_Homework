using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GateCounter gateCounterUI;
    public Image gameOverScreen;
    public Text gameOverText;
    public Image timerImage;

    public void Start()
    {
        gameOverScreen.gameObject.SetActive(false);
        timerImage.fillAmount = 1;
    }

    public void UpdateGateCounter(int gatesCount)
    {
        gateCounterUI.UpdateUI(gatesCount);
    }

    public void ShowGameOverScreenPassed()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "Passed";
        gameOverText.color = Color.green;
    }

    public void ShowGameOverScreenDeath()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "YOU DIED";
        gameOverText.color = Color.red;
    }

    public void ShowGameOverScreenFail()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "FAILED";
        gameOverText.color = Color.red;
    }

    public void ReloadMainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void SetTotalGates(int numGates)
    {
        gateCounterUI.MaxGates = numGates;
    }

    public void UpdateTimer(float defaultValue, float timeRemaining)
    {
        float percentMaxHealth = Mathf.InverseLerp(0, defaultValue, timeRemaining);
        timerImage.fillAmount = percentMaxHealth;
    }
}
