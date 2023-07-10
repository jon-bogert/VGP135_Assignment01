using UnityEngine;

public class PurchasePointsUpgrade : UpgradeButtonBase
{
    [SerializeField] ulong pointAmount = 1000;
    override protected void Setup()
    {
    }

    public override void OnPurchase()
    {
        gameManager.Score += pointAmount;
    }
}