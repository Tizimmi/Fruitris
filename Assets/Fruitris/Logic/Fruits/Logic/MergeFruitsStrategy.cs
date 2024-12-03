using UnityEngine;
using Zenject;

public class MergeFruitsStrategy
{
	[Inject]
	private readonly ScoreView _scoreView;
	[Inject]
	private readonly Spawner _spawner;

	public void Merge(Fruit firstFruit, Fruit secondFruit, Vector2 position)
	{
		if (int.Parse(firstFruit.tag) < _spawner.fruits.Count - 1)
			_spawner.SpawnFruit(int.Parse(firstFruit.tag), position);

		_scoreView.UpdateCurrentScore(firstFruit._value);
		Object.Destroy(firstFruit.gameObject);
		Object.Destroy(secondFruit.gameObject);
	}
}