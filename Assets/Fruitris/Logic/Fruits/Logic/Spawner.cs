using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<Fruit> _firstSpawnableFruits;
    [SerializeField]
    private Transform _fruitsRoot;
    [SerializeField]
    public List<Fruit> fruits;
    [SerializeField]
    private LayerMask _raycastMask;

    [Inject]
    private readonly GamePrefabFactory _gamePrefabFactory;

    private Vector2 _mousePositon;
    private Fruit _currentFruit;

    private void Update()
    {
        _mousePositon = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && CheckMousePosition())
        {
            _currentFruit = SpawnFruit(SelectFruit(), new Vector2(_mousePositon.x, gameObject.transform.position.y));
            _currentFruit.ChangeIsGravitational(false);
        }
        else if (Input.GetMouseButtonUp(0) && _currentFruit!=null)
        {
            _currentFruit.ChangeIsGravitational(true);
            _currentFruit.StartCoroutine("Timer");
            _currentFruit = null;

        }
        else if (Input.GetMouseButton(0) && CheckMousePosition() && _currentFruit != null)
        {
            _currentFruit.transform.position = new Vector2(_mousePositon.x, gameObject.transform.position.y);
        }
        
        
    }
    public Fruit SelectFruit()
    {
        return _firstSpawnableFruits[Random.Range(0,_firstSpawnableFruits.Count)];
    }

    public void SpawnFruit(int index, Vector2 spawnPosition)
    {
        SpawnFruit(fruits[index+1], spawnPosition);
    }
    
    public Fruit SpawnFruit(Fruit fruit, Vector2 spawnPosition)
    {
        fruit = _gamePrefabFactory.InstantiatePrefab<Fruit>(fruit, spawnPosition, Quaternion.identity, _fruitsRoot); ;
        return fruit;
    }

    public bool CheckMousePosition()
    {
        return Physics2D.Raycast(_mousePositon, Vector2.down, 5, _raycastMask);
    }

}