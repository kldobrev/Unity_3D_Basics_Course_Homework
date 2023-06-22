using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private enum GameState
    {
        Playing,
        Dead,
        Fail,
        Passed
    }
    
    [SerializeField]
    private UI ui;
    [SerializeField]
    private GatesController gatesController;
    [SerializeField]
    private PlaneAudio planeAudio;
    [SerializeField]
    private int totalGates;

    public float timer;
    public float timerDefaultValue = 20f;
    public float gateTimeBonusValue = 5f;
    private int gatesPassed = -1;
    private static GameState State { get; set; }
    private Coroutine lowerPlanePitch;
    private bool shouldPitchCoroutineStop;


    // Start is called before the first frame update
    void Start()
    {
        ui.SetTotalGates(totalGates);
        timer = timerDefaultValue;
        UpdateGatesPassedCount();
        State = GameState.Playing;
        shouldPitchCoroutineStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(State == GameState.Playing)
        {
            timer -= Time.deltaTime;
            ui.UpdateTimer(timerDefaultValue, timer);

            if (timer <= 0)
            {
                State = GameState.Fail;
                ui.ShowGameOverScreenFail();
            }

            if (gatesPassed >= totalGates)
            {
                State = GameState.Passed;
                ui.ShowGameOverScreenPassed();
            }
        }

        if (State == GameState.Dead && shouldPitchCoroutineStop)
        {
            StopCoroutine(lowerPlanePitch);
            shouldPitchCoroutineStop = false;
        }
    }

    private void UpdateGatesPassedCount()
    {
        gatesPassed += 1;
        ui.UpdateGateCounter(gatesPassed);
    }

    private void UpdateTime()
    {
        timer += gateTimeBonusValue;
        if(timer > timerDefaultValue)
        {
            timer = timerDefaultValue;
        }
        ui.UpdateTimer(timerDefaultValue, timer);
    }

    public void OnClickedRestart()
    {
        ui.ReloadMainScene();
    }

    public void OnGateTriggerPassed(Transform trns)
    {
        UpdateTime();
        UpdateGatesPassedCount();
        trns.GetComponent<Gate>().ToggleFlames(false);
        if(gatesPassed + 1 < totalGates && State == GameState.Playing)
        {
            Transform nextGate = gatesController.SpawnGate().transform;
            nextGate.GetComponent<Gate>().ToggleFlames(true);
        }
    }

    public void OnObstacleCollision()
    {
        State = GameState.Dead;
        ui.ShowGameOverScreenDeath();
        lowerPlanePitch = StartCoroutine(LowerPlanePitch());
    }

    private IEnumerator LowerPlanePitch()
    {
        while(true)
        {
            if(!planeAudio.LowerPitchToMin())
            {
                shouldPitchCoroutineStop = true;
            }
            yield return null;
        }
    }
}
