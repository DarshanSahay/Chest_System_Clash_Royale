using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestService : GenericSingleton<ChestService>
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource slotSource;
    [SerializeField] private ChestStats[] stats;
    [SerializeField] private ChestView view;
    [SerializeField] private Button creatChestBtn;
    [SerializeField] private GameObject InQueueMessagePanel;

    private ChestController chest;
    private ChestStates state;

    public GameObject UI;
    public GameObject EarlyUnlockUI;
    public GameObject ChestUnlockedUI;
    public GameObject ChestInQueueUI;
    

    public TextMeshProUGUI SilverText;
    public TextMeshProUGUI ExpText;
    public TextMeshProUGUI GemsText;
    public TextMeshProUGUI TimerText1;
    public TextMeshProUGUI TimerText2;
    public TextMeshProUGUI NoDiamondsText;

    public Image chestImage1;
    public Image chestImage2;
    public Image chestImage3;
    
    private void Start()
    {
        creatChestBtn.onClick.AddListener(EnableChest);
        if (state == ChestStates.Unlocking)
        {
            view.button.onClick.AddListener(OpenUI);
        }
    }

    public void EnableChest()
    {
        if (SlotManager.Instance.CheckSlots())
        {
            source.Play();
            CreateChest();
        }
    }

    public ChestController CreateChest()
    {
        ChestStats stat = stats[Random.Range(0, 9)];
        ChestModels model = new ChestModels(stat);
        chest = new ChestController(model, view);
        return chest;
    }

    public ChestController getChest()
    {
        return chest;
    }

    public void OpenUI()
    {
        if (state == ChestStates.Unlocking)
        {
            slotSource.Play();
            EarlyUnlockUI.gameObject.SetActive(true);
        }
    }
    public void DisableUI()
    {
        slotSource.Play();
        UI.gameObject.SetActive(false);
    }

    public void CloseEarlyUI()
    {
        EarlyUnlockUI.gameObject.SetActive(false);
    }

    public void OpenQueueMessagePanel()
    {
        InQueueMessagePanel.SetActive(true);
    }
    public void CloseQueueMessagePanel()
    {
        InQueueMessagePanel.SetActive(false);
    }
    public void CloseConfirmationQueue()
    {
        ChestInQueueUI.SetActive(false);
    }
}
