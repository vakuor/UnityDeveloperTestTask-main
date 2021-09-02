using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressView : MonoBehaviour
{
    public enum ProgressViewState
    {
        Locked,
        Done,
        InProgress
    }
    
    
    [SerializeField] private GameObject _ScoreView;
    [SerializeField] private TextMeshProUGUI _currentProgressText;
    [SerializeField] private TextMeshProUGUI _totalText;
    
    [SerializeField] private int _currentProgress;
    [SerializeField] private int _total;
    
    [SerializeField] private ProgressData.ProgressState status;
    
    
    [SerializeField] private Image _lockImage;
    [SerializeField] private Image _checkMark;
                 
                                                                    
    public void Initialize(ProgressData data)
    {
        _currentProgress = data.CurrentProgress;
        _total = data.Total;
        status = data.Status;
        switch (status)
        {
            case ProgressData.ProgressState.Locked:
                SetLocked();
                break;
            case ProgressData.ProgressState.Completed:
                SetCompleted();
                break;
            case ProgressData.ProgressState.InProgress:
                ShowProgress();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

    }

    public void SetLocked()
    {
        DisableAll();
        _lockImage.gameObject.SetActive(true);
    }
    public void SetCompleted()
    {
        DisableAll();
        _checkMark.gameObject.SetActive(true);
    }
    public void ShowProgress()
    {
        DisableAll();
        _ScoreView.SetActive(true);
        _currentProgressText.text = _currentProgress.ToString();
        _totalText.text = _total.ToString();
    }

    private void DisableAll()
    {
        _lockImage.gameObject.SetActive(false);
        _checkMark.gameObject.SetActive(false);
        _ScoreView.SetActive(false);
    }
    
    
}