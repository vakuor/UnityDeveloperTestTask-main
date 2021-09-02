using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour, IDisposable
{
	[SerializeField] private Animator _star;
	[SerializeField] private Animator _textAnimator;
	[SerializeField] private List<TextMeshProUGUI> _scoreFields;

	private static readonly int RotateHash = Animator.StringToHash("Rotate");
	private static readonly int ScaleHash = Animator.StringToHash("ScaleHash");

	[SerializeField] private int _currentScore;
	[SerializeField] private int _targetScore;

	public void Init(int score)
	{
		_targetScore = score;
		_currentScore = score;
		FillTextFields(score.ToString());
	}

	private void FillTextFields(string text)
	{
		foreach (var tmp in _scoreFields)
		{
			tmp.text = text;
		}
	}

	public void AddScore(int score)
	{
		_targetScore = _currentScore + score;
		AnimateScore();
		
	}

	private void AnimateScore()
	{
		PlayTextAnimation();
		PlayScaleAnimation();
		PlayStarAnimation();
	}

	private void PlayTextAnimation()
	{
		DOTween.To(() => _currentScore, x => _currentScore = x, _targetScore, 1)
			.OnUpdate(UpdateScore)
			.OnComplete(() =>
			{
				StopScaleAnimation(); 
				StopStarAnimation();
			});
	}

	private void UpdateScore()
	{
		FillTextFields(_currentScore.ToString());
	}

	private void PlayStarAnimation()
	{
		_star.SetBool(RotateHash, true);
	}

	private void PlayScaleAnimation()
	{
		_textAnimator.SetBool(ScaleHash, true);
	}private void StopStarAnimation()
	{
		_star.SetBool(RotateHash, false);
	}

	private void StopScaleAnimation()
	{
		_textAnimator.SetBool(ScaleHash, false);
	}

	public void Dispose()
	{
		throw new NotImplementedException();
	}
}
