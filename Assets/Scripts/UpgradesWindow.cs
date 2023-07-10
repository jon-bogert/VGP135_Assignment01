using System.Collections.Generic;
using UnityEngine;

public class UpgradesWindow : MonoBehaviour
{
    [SerializeField] GameObject _gridObject;
    [SerializeField] List<GameObject> _buttonPrefabs;
    
    List<UpgradeButtonBase> _buttons = new List<UpgradeButtonBase>();

    private void Start()
    {
        foreach (GameObject b in _buttonPrefabs)
        {
            UpgradeButtonBase buttonObj = Instantiate(b, _gridObject.transform).GetComponent<UpgradeButtonBase>();
            if (buttonObj is null)
            {
                Debug.LogWarning("Upgrades Window -> Could not find Upgrade Button Base Component");
            }
            else
            {
                _buttons.Add(buttonObj);
            }
        }

        if (gameObject.activeSelf)
            gameObject.SetActive(false);
    }
    public void ToggleMenu()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void ExitMenu()
    {
        gameObject.SetActive(false);
    }
}
