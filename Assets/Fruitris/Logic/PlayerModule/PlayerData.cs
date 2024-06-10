using System;

[Serializable]
public class PlayerData : IComparable<PlayerData>
{
	public string Nickname;
	public int MaxScore;

	public PlayerData(string nickname, int maxscore)
	{
		Nickname = nickname;
		MaxScore = maxscore;
	}

	public PlayerData(PlayerData player)
	{
		Nickname = player.Nickname;
		MaxScore = player.MaxScore;
	}

	public int CompareTo(PlayerData other)
	{
		if (MaxScore < other.MaxScore)
			return 1;

		if (MaxScore == other.MaxScore)
			return 0;

		return -1;
	}
}