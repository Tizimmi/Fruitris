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
	private int currentScore = 0;

    private void Start()
    {
		UpdateCurrentScore(0);
    }
    public void UpdateCurrentScore(int score)
	{
		_currentScoreArea.text = $"Current score: {currentScore += score}";
	}

	public void UpdateMaxScore(int score)
	{
		_maxScoreArea.text = $"Max score: {score}";
	}
}