using UnityEngine;

public class AutoClickerUpgrade : Upgrade
{
    public ulong pointAmt = 10;
    public override void Apply(GameManager gameManager)
    {
        gameManager.Score += pointAmt;
    }
}

public class AutoClickerUpgradeButton : UpgradeButtonBase
{
    ushort priceInc = 10;
    ulong pointAmt = 10;
    ushort pointInc = 10;
    override protected void Setup()
    {
        level = 1;
        price = 1000;
        nextUpgrade = new AutoClickerUpgrade();
    }

    protected override void OnPurchase()
    {
        gameManager.AddOrUpdateUpgrade(lastUpgrade, nextUpgrade);
        lastUpgrade = nextUpgrade;
        pointAmt *= pointInc;
        price *= priceInc;
        ++level;

        AutoClickerUpgrade next = new AutoClickerUpgrade();
        next.pointAmt = pointAmt;
        nextUpgrade = next;
    }
}