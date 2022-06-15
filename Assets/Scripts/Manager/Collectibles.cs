using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectibles : GenericSingleton<Collectibles>
{
    [SerializeField] private TextMeshProUGUI ExpText;
    [SerializeField] private TextMeshProUGUI SilverText;
    [SerializeField] private TextMeshProUGUI GemsText;

    public int totalGems = 50;
    public int totalExp = 100;
    public int totalSilver = 1000;

    private void Start()
    {
        UpdateCollectibles();
    }
    public void UpdateCollectibles()
    {
        GemsText.text = totalGems.ToString();
        ExpText.text = totalExp.ToString();
        SilverText.text = totalSilver.ToString();
    }
}
