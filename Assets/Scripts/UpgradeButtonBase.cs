using UnityEngine;

public enum UpgradeType { Click, Timed }

//Base class for creating upgrade buttons
public class UpgradeButtonBase : MonoBehaviour
{
    private GameManager _gameManager;
    protected GameManager gameManager { get { return _gameManager; } }
    protected ulong level = 1;
    protected ulong price = 0;
    protected Upgrade lastUpgrade = null;
    protected Upgrade nextUpgrade = null;

    protected string description = "<< No Description >>";
    public string Description { get { return description; } }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Setup();
    }

    //Use to setup how your upgrade will affect the game
    virtual protected void Setup() { }

    //What happens when item is purchased
    virtual protected void OnPurchase() { }
}

//BaseClass or the Upgrade itself
[System.Serializable]
public class Upgrade
{
    public float timer = 0f;
    public float triggerTime = 1f;
    protected UpgradeType type;
    public string name;
    public UpgradeType Type { get { return type; } }
    public virtual void Apply(GameManager gameManager) { }
}
