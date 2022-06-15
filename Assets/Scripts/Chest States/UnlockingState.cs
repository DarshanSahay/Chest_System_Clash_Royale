using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingState : States
{
    private bool isUnlocked = false;
    private float ChestTime;
    private ReadyToOpen unlocked;
    private GameObject unlockingState;
    [SerializeField] ChestView view;
    private int noOFDias;

    private void Start()
    {
        ChestTime = view.Timer;
    }
    public override States RunCurrentState()
    {
        if(view.state != ChestStates.ReadyToOpen)
        {
            StartTimer();
        }
        
        if (isUnlocked == true && view.isActive == true)
        {
            unlockingState.gameObject.SetActive(true);
            return unlocked;
        }
        return this;
    }
    public void StartTimer()
    {
        noOFDias = 1 + (int)ChestTime/5;

        ChestTime -= Time.deltaTime;
       
        view.CountDownText.text = ""+(int)ChestTime;
        ChestService.Instance.TimerText2.text = "Timer : " + (int)ChestTime;
        ChestService.Instance.NoDiamondsText.text = "Unlock Now For :  " + noOFDias;

        if (ChestTime <= 0 )
        {
            ChestTime = 0;
            view.state = ChestStates.Unlocked;
            view.CountDownText.fontSize = 17;
            view.CountDownText.text = "UNLOCKED";
            if(view.isActive == true)
            {
                unlockingState.gameObject.SetActive(true);
                isUnlocked = true;
            }
        }
        if(view.state == ChestStates.Unlocked)
        {
            view.CountDownText.fontSize = 17;
            view.CountDownText.text = "UNLOCK";

            if (view.isActive == true)
            {
                unlockingState.gameObject.SetActive(true);
                isUnlocked = true;
            }

            SlotManager.Instance.c_Status = SlotStatus.Idle;

            if (SlotManager.Instance.chestQueue.Count != 0)
            {
                ChestView cview = SlotManager.Instance.chestQueue.Peek();
                cview.UpdateUI();
                SlotManager.Instance.chestQueue.Dequeue();
                view.inQueue = false;
            }
            view.state = ChestStates.ReadyToOpen;
        }
    }

    public void EarlyUnlock()
    {
        if(Collectibles.Instance.totalGems >= noOFDias)
        {
            //StartTimer();
            view.state = ChestStates.Unlocked;
            Collectibles.Instance.totalGems -= noOFDias;
            if (view.isActive == true)
            {
                unlockingState.gameObject.SetActive(true);
                isUnlocked = true;
            }
            ChestService.Instance.EarlyUnlockUI.gameObject.SetActive(false);
            Collectibles.Instance.UpdateCollectibles();
            view.hasStarted = false;
        }
        else
        {
            Debug.Log("Insufficient Diamonds");
        }
    }
}
