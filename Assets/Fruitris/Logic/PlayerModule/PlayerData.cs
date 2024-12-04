using System;

namespace Fruitris.Logic.PlayerModule
{
	[Serializable]
	public class PlayerData : IComparable<PlayerData>
	{
		public string _nickname;
		public int _maxScore;

		public PlayerData(string nickname, int maxscore)
		{
			_nickname = nickname;
			_maxScore = maxscore;
		}

		public PlayerData(PlayerData player)
		{
			_nickname = player._nickname;
			_maxScore = player._maxScore;
		}

		public int CompareTo(PlayerData other)
		{
			if (_maxScore < other._maxScore)
				return 1;

			if (_maxScore == other._maxScore)
				return 0;

			return -1;
		}

		public void SavePlayerData()
		{
			PlayerSaveHandler.SavePlayerInfo(this);
		}
	}
}