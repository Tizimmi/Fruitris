using UnityEngine;
using Zenject;

public class GamePrefabFactory
{
    [Inject]
    private readonly DiContainer _container;

    public GameObject InstantiatePrefab(
            Object prefab,
            Vector3 position,
            Quaternion rotation,
            Transform parentTransform)
    {
        return _container.InstantiatePrefab(prefab, position, rotation, parentTransform);
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

}