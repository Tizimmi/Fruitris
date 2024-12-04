using Fruitris.Logic.Fruits.Logic;
using System.Collections.Generic;

public class CollisionInfoCollection
{
	private class CollisionInfo
	{
		public readonly Fruit FirstFruit;
		public readonly Fruit SecondFruit;

		public CollisionInfo(Fruit firstFruit, Fruit secondFruit)
		{
			FirstFruit = firstFruit;
			SecondFruit = secondFruit;
		}
	}

	private readonly List<CollisionInfo> _collection = new();

	public void AddItemInCollection(Fruit firstFruit, Fruit secondFruit)
	{
		_collection.Add(new CollisionInfo(firstFruit, secondFruit));
	}

	public bool Contains(Fruit fruit)
	{
		foreach (var item in _collection)
			if (item.FirstFruit == fruit || item.SecondFruit == fruit)
				return true;

		return false;
	}
}