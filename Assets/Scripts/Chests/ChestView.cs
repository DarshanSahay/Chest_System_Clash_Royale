using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestView : MonoBehaviour
{
    #region Chest Data Public Variables

    public int Timer; 
    public int MaxGold; 
    public int MinGold;
    public int MaxGems;
    public int MinGems;
    public int MaxExp;
    public int MinExp;
    [SerializeField] private string Name;
    [SerializeField] private Sprite ChestImage;
    [SerializeField] private Image image;

    #endregion

    #region UI Public Variables

    public TextMeshProUGUI CountDownText;
    public Button button;
    public Button UnlockedBtn;

    [SerializeField] private Button UnlockBtn;
    [SerializeField] private GameObject timer;
    [SerializeField] private Button EarlyUnlockBtn;

    #endregion

    #region Instance Variables

    private int count = 0;
    public bool inQueue = false;
    public bool hasStarted = false;
    public ChestStates state;
    public bool isActive = false;

    [SerializeField] private UnlockingState unlockState;  
    [SerializeField] private ReadyToOpen rState;  
    [SerializeField] private ChestService service;  
    [SerializeField] private ChestModels model;  
    [SerializeField] private SlotManager slotManager; 

    #endregion
    
    private void Start()
    {
        service = ChestService.Instance;
        slotManager = SlotManager.Instance;
        button.onClick.AddListener(ShowStats);
        model = ChestService.Instance.getChest().Model;
        SetStats();
    }

    public void SetStats()
    {
        Name = model.ChestName;
        Timer   = model.ChestTime;
        MinGold = model.MinChestGold;
        MaxGold = model.MaxChestGold;
        MinGems = model.MinChestGems;
        MaxGems = model.MaxChestGems;
        MinExp  = model.MinChestExp;
        MaxExp  = model.MaxChestExp;
        ChestImage = model.chestImage;
        image.sprite = ChestImage;
    }

    public void ShowStats()
    {
        if (state == ChestStates.Locked)
        {
            if(slotManager.c_Status == SlotStatus.UnlockingChest)
            {
                if (inQueue)
                {
                    service.OpenQueueMessagePanel();
                }
                else
                {
                    service.ChestInQueueUI.SetActive(true);
                    Button addQueue = service.ChestInQueueUI.GetComponentInChildren<Button>();
                    addQueue.onClick.AddListener(UpdateUI);
                }
            }
            else
            {
                service.UI.gameObject.SetActive(true);
                UnlockBtn = service.UI.GetComponentInChildren<Button>();
                UnlockBtn.onClick.AddListener(UpdateUI);

                service.SilverText.text = (MinGold + "-" + MaxGold).ToString();
                service.GemsText.text = (MinGems + "-" + MaxGems).ToString();
                service.ExpText.text = (MinExp + "-" + MaxExp).ToString();
                service.TimerText1.text = Timer.ToString();
                service.chestImage1.sprite = ChestImage;
            }
        }
        if(state == ChestStates.Unlocking)
        {
            service.EarlyUnlockUI.gameObject.SetActive(true);
            service.chestImage2.sprite = ChestImage;
            EarlyUnlockBtn = service.EarlyUnlockUI.GetComponentInChildren<Button>();
            EarlyUnlockBtn.onClick.AddListener(unlockState.EarlyUnlock);
        }
        if(state == ChestStates.ReadyToOpen)
        {
            isActive = true;
            service.ChestUnlockedUI.gameObject.SetActive(true);
            UnlockedBtn = service.ChestUnlockedUI.GetComponentInChildren<Button>();
            UnlockedBtn.onClick.AddListener(rState.CollectRewards);
            service.chestImage3.sprite = ChestImage;
        }
    }

    public void UpdateUI()
    {
        if(slotManager.c_Status == SlotStatus.Idle)
        {
            hasStarted = true;
            state = ChestStates.Unlocking;
            service.UI.gameObject.SetActive(false);
            UnlockBtn = null;
            timer.gameObject.SetActive(true);
            slotManager.c_Status = SlotStatus.UnlockingChest;
        }
        else
        {
            if(count == 0)
            {
                slotManager.chestQueue.Enqueue(this);
                CountDownText.fontSize = 17;
                CountDownText.text = "Queued";
                service.ChestInQueueUI.SetActive(false);
                count++;
                inQueue = true;
            }
        }
    }
}
