using System.Collections.Generic;
using UnityEngine;

public class UpgradesWindow : MonoBehaviour
{

    private enum State { Open, Closed, Opening, Closing }
    [SerializeField] GameObject _gridObject;
    [SerializeField] List<GameObject> _buttonPrefabs;
    [SerializeField] float _travelTime = 2f;
    [SerializeField] float _travelWeight = 0.1f;
    [SerializeField] Transform _closedTransform;

    List<UpgradeButtonBase> _buttons = new List<UpgradeButtonBase>();

    float _timer = 0f;
    State _state = State.Closed;
    Vector2 _openPoint;
    Vector2 _closedPoint;

    private void Awake()
    {
        _openPoint = transform.position;
        _closedPoint = new Vector2 (transform.position.x, _closedTransform.position.y);
        transform.position = _closedPoint;
    }

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
    }

    private void Update()
    {
        if (_state == State.Closed || _state == State.Open)
            return;

        if (_state == State.Opening)
        {
            if (_timer < _travelTime)
            {
                transform.position = new Vector2(transform.position.x, XephMath.QuadLerp(_closedPoint.y, _openPoint.y, _travelWeight, _timer / _travelTime));
            }
            else
            {
                transform.position = _openPoint;
                _state = State.Open;
            }
        }
        else if (_state == State.Closing)
        {
            if (_timer < _travelTime)
            {
                transform.position = new Vector2(transform.position.x, XephMath.QuadLerp(_openPoint.y, _closedPoint.y, 1f - _travelWeight, _timer / _travelTime));
            }
            else
            {
                transform.position = _closedPoint;
                _state = State.Closed;
            }
        }
        _timer += Time.unscaledDeltaTime;
    }

    public void ToggleMenu()
    {
        switch (_state)
        {
            case State.Closed:
                _state = State.Opening;
                _timer = 0f;
                break;
            case State.Open:
                _state = State.Closing;
                _timer = 0f;
                break;
            default:
                break; // Should no nothing if in transition
        }
    }

    public void ExitMenu()
    {
        if (_state == State.Open)
        {
            _state = State.Closing;
            _timer = 0f;
        }
    }
}
