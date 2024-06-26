using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _currentScoreArea;
    [SerializeField]
    private TextMeshProUGUI _maxScoreArea;
    [SerializeField]
    private int _currentScore = 0;
    [SerializeField]
    private int _maxScore = 0;

    [Inject]
    private readonly LeaderBoardView _leaderboardView;

    private void Start()
    {
        UpdateCurrentScore(_currentScore);
    }

    public void UpdateCurrentScore(int score)
    {  
        _currentScoreArea.text = $"Current score: {_currentScore += score}";

        if (_currentScore > _maxScore && _currentScore > GameStateHandler._currentPlayer.MaxScore)
        {
            GameStateHandler._currentPlayer.MaxScore = _currentScore;
            UpdateMaxScore(_currentScore);
        }
    }

    public void UpdateMaxScore(int score)
    {
        _maxScoreArea.text = $"Max score: {score}";
    }
}