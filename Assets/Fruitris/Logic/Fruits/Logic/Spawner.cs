using Fruitris.Logic.GameModule.GameInstallers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Fruitris.Logic.Fruits.Logic
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField]
		public List<Fruit> _fruits;
		public float _cooldownTimer = 0.25f;
		[SerializeField]
		private List<Fruit> _firstSpawnableFruits;
		[SerializeField]
		private Transform _fruitsRoot;
		[SerializeField]
		private LayerMask _raycastMask;

		[Inject]
		private readonly GamePrefabFactory _gamePrefabFactory;
		private bool _canSpawn = true;
		private Fruit _currentFruit;

		private Vector2 _mousePosition;
		private float _timer;

		private void Start()
		{
			_timer = _cooldownTimer;
		}

		private void Update()
		{
			if (Camera.main != null)
				_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Input.GetMouseButtonDown(0) && CheckMousePosition() && _canSpawn)
			{
				_currentFruit = SpawnFruit(SelectFruit(), new Vector2(_mousePosition.x, gameObject.transform.position.y));
				_currentFruit.ChangeIsGravitational(false);
			}
			else if (Input.GetMouseButtonUp(0) && _currentFruit != null)
			{
				_currentFruit.ChangeIsGravitational(true);
				_currentFruit.StartCoroutine(nameof(Fruit.Timer));
				_currentFruit = null;
				StartCoroutine(nameof(Timer));
			}
			else if (Input.GetMouseButton(0) && CheckMousePosition() && _currentFruit != null)
			{
				_currentFruit.transform.position = new Vector2(_mousePosition.x, gameObject.transform.position.y);
			}
		}

		public IEnumerator Timer()
		{
			_canSpawn = false;

			while (_timer > 0)
			{
				_timer -= Time.deltaTime;
				yield return null;
			}

			_timer = _cooldownTimer;
			_canSpawn = true;
		}

		public void SpawnFruit(int index, Vector2 spawnPosition)
		{
			SpawnFruit(_fruits[index + 1], spawnPosition);
		}

		private Fruit SelectFruit()
		{
			return _firstSpawnableFruits[Random.Range(0, _firstSpawnableFruits.Count)];
		}

		private Fruit SpawnFruit(Fruit fruit, Vector2 spawnPosition)
		{
			fruit = _gamePrefabFactory.InstantiatePrefab<Fruit>(fruit,
				spawnPosition,
				Quaternion.identity,
				_fruitsRoot);

			return fruit;
		}

		private bool CheckMousePosition()
		{
			return Physics2D.Raycast(_mousePosition,
				Vector2.down,
				5,
				_raycastMask);
		}
	}
}