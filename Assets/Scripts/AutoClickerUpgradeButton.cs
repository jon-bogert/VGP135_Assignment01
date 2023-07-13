using UnityEngine;
using TMPro;

public class AutoClickerUpgrade : Upgrade
{
    public ulong pointAmt = 10;
    public void Setup()
    {
        type = UpgradeType.Timed;
        name = "default auto-clicker";
    }
    public override void Apply(GameManager gameManager)
    {
        gameManager.Score += pointAmt;
    }
}

public class AutoClickerUpgradeButton : UpgradeButtonBase
{
    [SerializeField] TMP_Text levelCostText;

    ushort priceInc = 10;
    ulong pointAmt = 10;
    ushort pointInc = 10;
    override protected void Setup()
    {
        level = 1;
        price = 1000;
        AutoClickerUpgrade newAutoClicker = new AutoClickerUpgrade();
        newAutoClicker.Setup();
        nextUpgrade = newAutoClicker;
        UpdateText();
    }

    public override void OnPurchase()
    {
        //Check if has enough points
        if (gameManager.Score < price)
        {
            Debug.Log("Not enouph points"); // TODO create in-game dialogue
            return;
        }
        gameManager.Score -= price;
        gameManager.AddOrUpdateUpgrade(lastUpgrade, nextUpgrade);
        lastUpgrade = nextUpgrade;
        pointAmt *= pointInc;
        price *= priceInc;
        ++level;

        AutoClickerUpgrade next = new AutoClickerUpgrade();
        next.Setup();
        next.pointAmt = pointAmt;
        nextUpgrade = next;
        UpdateText();
    }
    void UpdateText()
    {
        levelCostText.text = "Level: " + level.ToString() + "\nCost: " + price.ToString() + " Pts";
    }
}