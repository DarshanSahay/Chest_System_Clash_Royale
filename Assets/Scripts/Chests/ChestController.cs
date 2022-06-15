using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController
{
    public ChestModels Model { get; }
    public  ChestView View { get; }

    public ChestController(ChestModels model,ChestView view)
    {
        Model = model;
        View = GameObject.Instantiate<ChestView>(view,SlotManager.Instance.CreateSlot());
    }
}
