using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    // Inspector
    [SerializeField] string _scoreTextLabel = "Score: ";

    // Data
    ulong _score = 0;
    ulong _clickAmt = 1;

    // Public Delegates
    [HideInInspector]
    public UnityEvent clickPerformed; // Subscribed/Unsubscribed to/from other scripts

    private List<Upgrade> _onClickUpgrades = new List<Upgrade>();
    private List<Upgrade> _timedUpgrades = new List<Upgrade>();

    // Properties
    public ulong ClickAmount { get { return _clickAmt; } set { _clickAmt = value; } }
    public string ScoreText { get { return _scoreTextLabel + _score.ToString(); } }
    public ulong Score { get { return _score; } set { _score = value; } }


    private void Update()
    {
        for(int i = 0; i < _timedUpgrades.Count; ++i)
        {
            if (_timedUpgrades[i].timer >= _timedUpgrades[i].triggerTime)
            {
                _timedUpgrades[i].Apply(this);
                _timedUpgrades[i].timer -= _timedUpgrades[i].triggerTime;
            }
        }
    }

    // Events
    public void OnButtonClick()
    {
        _score += _clickAmt;
        foreach (Upgrade upgrade in _onClickUpgrades)
        {
            upgrade.Apply(this);
        }
        clickPerformed?.Invoke();
    }

    public void AddOrUpdateUpgrade(Upgrade lastUpgrade, Upgrade newUpgrade)
    {
        if (lastUpgrade.Type == newUpgrade.Type)
            return;

        List<Upgrade> upgrades;
        switch (lastUpgrade.Type)
        {
            case UpgradeType.Click:
                upgrades = _onClickUpgrades;
                break;
            case UpgradeType.Timed:
                upgrades = _timedUpgrades;
                break;
            default:
                Debug.LogWarning("Upgrade Type not implemented");
                return;
        }

        if (!(lastUpgrade is null))
        {
            upgrades.Remove(lastUpgrade);
        }
        upgrades.Add(newUpgrade);
    }
}
