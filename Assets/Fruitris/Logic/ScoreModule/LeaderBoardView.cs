using Fruitris.Logic.GameModule.GameInstallers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Fruitris.Logic.ScoreModule
{
	public class LeaderBoardView : MonoBehaviour
	{
		[SerializeField]
		private LeaderBoardItemView _leaderBoardItemPrefab;
		[SerializeField]
		private int _panelCapacity;
		[SerializeField]
		private Transform _root;
		[Inject]
		private readonly GamePrefabFactory _gamePrefabFactory;

		private readonly List<LeaderBoardItemView> _items = new();

		private void Start()
		{
			_panelCapacity = LeaderBoard.AllPlayers.Count;
			Init();
		}

		private void Init()
		{
			for (var i = 0; i < _panelCapacity; i++)
			{
				var prefab = _gamePrefabFactory.InstantiatePrefab<LeaderBoardItemView>(_leaderBoardItemPrefab, _root);
				prefab.Init(LeaderBoard.GetTopPlayers(ref _panelCapacity)[i], i + 1);
				_items.Add(prefab);
			}
		}

		public void UpdateLeaderBoard()
		{
			var length = _items.Count;
			for (var i = 0; i < length; i++)
				_items[i].Init(LeaderBoard.GetTopPlayers(ref length)[i], i + 1);
		}
	}
}