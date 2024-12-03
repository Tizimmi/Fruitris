using System;
using System.Collections.Generic;
using UnityEngine;

public static class LeaderboardSaveHandler
{
	[Serializable]
	public class SaveData
	{
		public List<PlayerData> _allPlayerData = new();

		public SaveData(List<PlayerData> data)
		{
			_allPlayerData = data;
		}

		public SaveData() { }
	}

	const string SaveKey = "LeaderboardSave";

	public static SaveData Load()
	{
		PlayerPrefs.GetString(SaveKey, "default");
		SaveData saveInfo;
		if (PlayerPrefs.HasKey(SaveKey))
		{
			var json = PlayerPrefs.GetString(SaveKey);
			saveInfo = JsonUtility.FromJson<SaveData>(json);
		}
		else
		{
			saveInfo = new SaveData();
		}

		return saveInfo;
	}

	public static void Save(SaveData data)
	{
		var json = JsonUtility.ToJson(data);
		PlayerPrefs.SetString(SaveKey, json);
	}
}