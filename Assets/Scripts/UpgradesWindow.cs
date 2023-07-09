using System.Collections.Generic;
using UnityEngine;

public class UpgradesWindow : MonoBehaviour
{
    [SerializeField] List<GameObject> buttonPrefabs;
    
    List<UpgradeButtonBase> buttons;


    private void Awake()
    {
        // TODO - Instantiate buttons in grid and populate button list
    }
}
