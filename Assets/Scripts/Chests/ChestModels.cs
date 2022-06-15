using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestModels
{
    #region Public Properties
    public ChestTypes ChestType { get; }
    public string ChestName { get; }
    public int ChestTime { get; }
    public int MinChestGems { get; }
    public int MaxChestGems { get; }
    public int MinChestGold { get; }
    public int MaxChestGold { get; }
    public int MinChestExp { get; }
    public int MaxChestExp { get; }
    public Sprite chestImage { get; }
    #endregion

    public ChestModels(ChestStats stats)
    {
        ChestType = stats.Type;
        ChestName = stats.ChestName;
        ChestTime = stats.Time;
        MinChestGems = stats.MinGems;
        MaxChestGems = stats.MaxGems;
        MinChestGold = stats.MinGold;
        MaxChestGold = stats.MaxGold;
        MinChestExp = stats.MinExp;
        MaxChestExp = stats.MaxExp;
        chestImage = stats.ChestImage;
    }
}
