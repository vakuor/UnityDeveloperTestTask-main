using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardTitleView : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _texts;

    public void Initialize(string title)
    {
        foreach (var field in _texts)
        {
            field.text = title;
        }
    }
}
