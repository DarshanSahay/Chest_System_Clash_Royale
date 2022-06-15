using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Chests", menuName = "Chest Data", order = 51)]
public class ChestStats : ScriptableObject
{
    public ChestTypes Type;
    public string ChestName;
    public int Time;
    public int MinGems;
    public int MaxGems; 
    public int MinGold;
    public int MaxGold;
    public int MinExp;
    public int MaxExp;
    public Sprite ChestImage;
}
