using UnityEngine;
using Views;

public class UIViewController : MonoBehaviour
{
    [SerializeField] private CardsStackView _cardsStackView;
    [SerializeField] private ScoreView _scoreView;

    private void Start()
    {
        _cardsStackView.Initialize(Card.GetAllInstances());
        _scoreView.Init(score: 0);
    }

    public void AddScore(int score)
    {
        _scoreView.AddScore(score);
    }
}
