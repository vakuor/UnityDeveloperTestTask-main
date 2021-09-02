using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Views;

namespace Views
{
    public class CardsStackView : MonoBehaviour
    {
        [SerializeField] private CardView _cardViewPrefab;
        [SerializeField] private Transform _contentParent;
        [SerializeField] private Scrollbar _scrollbar;
        
        [Header("Images to appear while scrolling")]
        [SerializeField] private List<Image>  _leftSide;
        [SerializeField] private List<Image> _rightSide;

        private List<CardView> _cardPanels = new List<CardView>();
        private Action<float> OnScroll;

        public void Initialize(List<Card> cards)
        {
            Reset();
            foreach (var card in cards)
            {
                var cardPanel = GenerateCard(card);
                _cardPanels.Add(cardPanel);
            }
            _scrollbar.onValueChanged.AddListener(ShowArrows);
        }

        private void ShowArrows(float value)
        {
            var leftValue = Mathf.Clamp01(Mathf.Pow(value,0.7f)*5);
            var rightValue = Mathf.Clamp01(Mathf.Pow(1-value, 0.7f) *5);
            foreach (var image in _leftSide)
            {
                image.color = new Color(1f, 1f, 1f, leftValue);
            }
            foreach (var image in _rightSide)
            {
                image.color = new Color(1f, 1f, 1f, rightValue);
            }
            
        }

        private CardView GenerateCard(Card card)
        {
            CardView cardView = Instantiate(_cardViewPrefab, _contentParent, false);
            cardView.Initialize(card);
            cardView.PlayButton.OnClick += PlayLevel;
            return cardView;
        }

        private void PlayLevel(Card card)
        {
            Debug.Log($"Open Scene: {card.SceneName}");
        }



        private void Reset()
        {
            foreach (var cardView in _cardPanels)
            {
                Destroy(cardView.gameObject);
            }
            _cardPanels.Clear();
        }
    }
}
