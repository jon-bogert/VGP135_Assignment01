using UnityEngine;

public class PointAmountUpgrade : UpgradeButtonBase
{
    ulong nextPointMultiplier = 5;
    ushort pointInc = 5;
    ushort priceInc = 2;
    override protected void Setup()
    {
        level = 1;
        price = 50;
    }

    protected override void OnPurchase()
    {
        gameManager.ClickAmount = nextPointMultiplier;
        nextPointMultiplier += pointInc;
        price *= priceInc;
        level += 1;
    }
}