using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LeaderBoardView : MonoBehaviour
{
    [Inject]
    private readonly GamePrefabFactory _gamePrefabFactory;

    [SerializeField]
    private LeaderBoardItemView _leaderBoardItemPrefab;
    [SerializeField]
    private int _panelCapacity;
    [SerializeField]
    private Transform _root;

    private List<LeaderBoardItemView> _items = new();
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        for (int i = 0; i < _panelCapacity; i++)
        {
            LeaderBoardItemView prefab = _gamePrefabFactory.InstantiatePrefab<LeaderBoardItemView>(_leaderBoardItemPrefab, _root);
            prefab.Init(LeaderBoard.GetTopPlayers(ref _panelCapacity)[i], i + 1);
            _items.Add(prefab);
        }
    }

    public void UpdateLeaderBoard()
    {
        int length = _items.Count;
        for (int i = 0; i < length; i++)
        {
            _items[i].Init(LeaderBoard.GetTopPlayers(ref length)[i], i+1);
        }
    }
}
