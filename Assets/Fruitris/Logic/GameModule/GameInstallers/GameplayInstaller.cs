using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Spawner _spawner;
    [SerializeField]
    private ScoreView _scoreView;
    [SerializeField]
    private GameObject _playerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromResolveGetter<GamePrefabFactory>(factory => factory.InstantiatePrefab<Player>(_playerPrefab, Vector3.zero, Quaternion.identity, gameObject.transform)).AsSingle().NonLazy();
        Container.Bind<Spawner>().FromInstance(_spawner).AsSingle().NonLazy();
        Container.Bind<ScoreView>().FromInstance(_scoreView).AsSingle().NonLazy();
        Container.Bind<LeaderBoard>().FromNew().AsSingle();
        Container.Bind<MergeFruitsStrategy>().FromNew().AsSingle().NonLazy();
    }  
	
	const string SaveKey = "localSave";

	private SaveInfo Load()
	{
		PlayerPrefs.GetString(SaveKey, "");
		SaveInfo saveInfo;
		if (PlayerPrefs.HasKey(SaveKey))
		{
			var json = PlayerPrefs.GetString(SaveKey);
			saveInfo = JsonUtility.FromJson<SaveInfo>(json);
		}
		else
		{
			saveInfo = new SaveInfo();
		}

		return saveInfo;
	}

	private void Save(SaveInfo data)
	{
		var json = JsonUtility.ToJson(data);
		PlayerPrefs.SetString(SaveKey, json);
	}

	private void Test()
	{
		var SaveData = new SaveInfo();
		SaveData.PlayerData = new List<PlayerData>()
		{
			new("123", 123),
			new("1233R1AS", 123),
			new("1233R1ASS", 123),
			new("1233R1AAASDASDS", 123),
			new("1QWDASVFC233R1AS", 123)
		};

		var json = JsonUtility.ToJson(SaveData);
		Debug.Log(json);

		var data = JsonUtility.FromJson<SaveInfo>(json);
	}

	[Serializable]
	public class SaveInfo
	{
		public List<PlayerData> PlayerData = new();
	}
}
