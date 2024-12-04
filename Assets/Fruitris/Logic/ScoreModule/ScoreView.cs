using Fruitris.Logic.GameModule.GameManagmentLogic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Fruitris.Logic.ScoreModule
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _currentScoreArea;
		[SerializeField]
		private TextMeshProUGUI _maxScoreArea;
		[SerializeField]
		private int _currentScore;
		[SerializeField]
		private int _maxScore;

		private void Start()
		{
			UpdateCurrentScore(_currentScore);
			UpdateMaxScore(GameStateHandler._currentPlayer._maxScore);
		}

		public void UpdateCurrentScore(int score)
		{
			_currentScoreArea.text = $"Current score: {_currentScore += score}";

			if (_currentScore > _maxScore && _currentScore > GameStateHandler._currentPlayer._maxScore)
			{
				GameStateHandler._currentPlayer._maxScore = _currentScore;
				UpdateMaxScore(_currentScore);
			}
		}

		private void UpdateMaxScore(int score)
		{
			_maxScoreArea.text = $"Max score: {score}";
		}
	}
}