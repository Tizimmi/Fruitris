using Fruitris.Logic.PlayerModule;
using TMPro;
using UnityEngine;

namespace Fruitris.Logic.ScoreModule
{
	public class LeaderBoardItemView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _playerNameAndScore;

		public void Init(PlayerData player, int place)
		{
			_playerNameAndScore.text = $"{place}. {player._nickname}:{player._maxScore}";
		}
	}
}