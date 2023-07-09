using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ScoreText : MonoBehaviour
{
    TMP_Text _textField;
    GameManager _gameManager;

    private void Awake()
    {
        _textField = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager)
            _gameManager.clickPerformed.AddListener(UpdateText);
        else
            Debug.LogWarning("Score Text -> No GameManager found in scene");

        UpdateText();
    }

    private void OnDestroy()
    {
        if (_gameManager)
            _gameManager.clickPerformed.RemoveListener(UpdateText);
    }

    void UpdateText()
    {
        _textField.text = _gameManager.ScoreText;
    }
}