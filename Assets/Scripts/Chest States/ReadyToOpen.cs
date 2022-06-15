using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToOpen : States
{
    public ChestView view;

    private void Start()
    {
        view.UnlockedBtn.onClick.AddListener(CollectRewards);
    }
    public override States RunCurrentState()
    { 
        return this;
    }
    public void CollectRewards()
    {
        Collectibles.Instance.totalGems += Random.Range(view.MinGems, view.MaxGems);
        Collectibles.Instance.totalExp += Random.Range(view.MinExp, view.MaxExp);
        Collectibles.Instance.totalSilver += Random.Range(view.MinGold, view.MaxGold);
        ChestService.Instance.ChestUnlockedUI.gameObject.SetActive(false);
        Collectibles.Instance.UpdateCollectibles();
        Destroy(view.gameObject);
    }
}
