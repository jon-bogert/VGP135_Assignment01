using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] Sprite _onSprite;
    [SerializeField] Sprite _offSprite;

    Image _image;
    AudioSource _audioSource;

    bool _isPlaying = true;

    private void Awake()
    {
        _image= GetComponent<Image>();
        _audioSource= GetComponent<AudioSource>();
    }

    public void ToggleMusic()
    {
        _isPlaying = !_isPlaying;
        if (_isPlaying)
        {
            _image.sprite = _onSprite;
            _audioSource.UnPause();
        }
        else
        {
            _image.sprite = _offSprite;
            _audioSource.Pause();
        }
    }
}
