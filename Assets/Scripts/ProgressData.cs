using System;

[Serializable]
public class ProgressData
{
    public enum ProgressState
    {
        Locked,
        Completed,
        InProgress
    }
    public int CurrentProgress;
    public int Total;
    public ProgressState Status;

    public ProgressData(int currentProgress, int total, ProgressState progressStatus)
    {
        CurrentProgress = currentProgress;
        Total = total;
        Status = progressStatus;
    }
}
