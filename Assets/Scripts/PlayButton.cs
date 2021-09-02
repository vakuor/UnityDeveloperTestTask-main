using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayButton : MonoBehaviour
{
    public event Action<Card> OnClick;
    
    [SerializeField] private Button _button;


    private Card _card;
    
    
    
    public void Initialize(Card card)
    {
        _card = card;
        _button.onClick.AddListener(ClickHandler);
        
    }
    
    private void ClickHandler() => OnClick?.Invoke(_card);
    
    public void SetActive(bool active) => gameObject.SetActive(active);
}