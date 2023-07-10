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

    public override void OnPurchase()
    {
        //Check if has enough points
        if (gameManager.Score < price)
        {
            Debug.Log("Not enouph points"); // TODO create in-game dialogue
            return;
        }
        gameManager.Score -= price;
        gameManager.ClickAmount = nextPointMultiplier;
        nextPointMultiplier += pointInc;
        price *= priceInc;
        level += 1;
    }
}