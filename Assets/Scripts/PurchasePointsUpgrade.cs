using TMPro;
using UnityEngine;

public class PurchasePointsUpgrade : UpgradeButtonBase
{
    [SerializeField] ulong pointAmount = 1000;
    [SerializeField] float cost = 0.99f;
    [SerializeField] TMP_Text costText;
    [SerializeField] TMP_Text titleText;
    override protected void Setup()
    {
        titleText.text = "Buy Points\n" + pointAmount.ToString();
        costText.text = "Cost: " + cost.ToString("c2");
    }

    public override void OnPurchase()
    {
        gameManager.Score += pointAmount;
    }
}