using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotStatus
{
    Idle,
    UnlockingChest
}

public class SlotManager : GenericSingleton<SlotManager>
{
    [SerializeField] private Transform[] slots;
    [SerializeField] private GameObject UI;

    public Queue<ChestView> chestQueue;
    public SlotStatus c_Status;
    private Transform slot;

    private void Start()
    {
        c_Status = SlotStatus.Idle;
        chestQueue = new Queue<ChestView>();
    }

    public bool CheckSlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                slot = slots[i].transform;
                return true;
            }
        }
        OpenSlotUI();
        return false;
    }
    public Transform CreateSlot()
    {
        return slot;
    }
    private void OpenSlotUI()
    {
        UI.gameObject.SetActive(true);
    }

    public void CloseSlotUI()
    {
        UI.gameObject.SetActive(false);
    }
}
