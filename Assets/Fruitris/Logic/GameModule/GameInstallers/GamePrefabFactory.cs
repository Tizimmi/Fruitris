using UnityEngine;
using Zenject;

namespace Fruitris.Logic.GameModule.GameInstallers
{
	public class GamePrefabFactory
	{
		[Inject]
		private readonly DiContainer _container;

		private GameObject InstantiatePrefab(
			Object prefab,
			Vector3 position,
			Quaternion rotation,
			Transform parentTransform)
		{
			return _container.InstantiatePrefab(prefab,
				position,
				rotation,
				parentTransform);
		}

		private GameObject InstantiatePrefab(Object prefab, Transform root)
		{
			return _container.InstantiatePrefab(prefab, root);
		}

		public T InstantiatePrefab<T>(
			Object prefab,
			Vector3 position,
			Quaternion rotation,
			Transform parentTransform)
			where T : Component
		{
			return InstantiatePrefab(prefab,
					position,
					rotation,
					parentTransform)
				.GetComponent<T>();
		}

		public T InstantiatePrefab<T>(Object prefab, Transform parentTransform)
			where T : Component
		{
			return InstantiatePrefab(prefab, parentTransform).GetComponent<T>();
		}
	}
}