using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public static Action<bool> OnStateChange;

    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Button button;
    
    private bool state;

    private void Awake()
    {
        state = true;
        button.image.sprite = onSprite;
        OnStateChange?.Invoke(state);
        button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    private void OnClick()
    {
        state = !state;
        var sprite = state ? onSprite : offSprite;
        
        button.image.sprite = sprite;
        OnStateChange?.Invoke(state);
    }
}
