using TMPro;
using UnityEngine;

public class ScoreMultiplierUpgrade : UpgradeButtonBase
{
    [SerializeField] ushort multiplyAmount = 2;
    [SerializeField] float cost = 0.99f;
    [SerializeField] TMP_Text costText;
    [SerializeField] TMP_Text titleText;
    override protected void Setup()
    {
        titleText.text = "Multiply Points\n x" + multiplyAmount.ToString();
        costText.text = "Cost: " + cost.ToString("c2");
    }

    public override void OnPurchase()
    {
        gameManager.Score = gameManager.Score * multiplyAmount;
    }
}
