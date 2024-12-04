using Fruitris.Logic.GameModule.GameManagmentLogic;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Fruitris.Logic.Fruits.Logic
{
	public class Fruit : MonoBehaviour
	{
		private static readonly CollisionInfoCollection Collisions = new();
		[SerializeField]
		public int _value;
		[SerializeField]
		private Rigidbody2D _rb2d;
		[SerializeField]
		private Object _prefabReference;
		[SerializeField]
		private float _invulnerabilityTimer;

		[Inject]
		private readonly MergeFruitsStrategy _merger;

		private bool _canFinish;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (!collision.gameObject.CompareTag(gameObject.tag))
				return;

			var firstFruit = this;
			var secondFruit = collision.gameObject.GetComponent<Fruit>();
			if (Collisions.Contains(secondFruit) || Collisions.Contains(firstFruit))
				return;

			Collisions.AddItemInCollection(firstFruit, secondFruit);
			Vector3 spawnPoint = new();
			foreach (var contactPoint in collision.contacts)
			{
				var hitPoint = contactPoint.point;
				spawnPoint = new Vector3(hitPoint.x, hitPoint.y, 0);
			}

			_merger.Merge(firstFruit, secondFruit, spawnPoint);
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (_canFinish && other.gameObject.CompareTag("GameOverTrigger"))
				GameStateHandler.GameOver();
		}

		public IEnumerator Timer()
		{
			while (_invulnerabilityTimer > 0)
			{
				_invulnerabilityTimer -= Time.deltaTime;
				yield return null;
			}

			_canFinish = true;
		}

		public void ChangeIsGravitational(bool value)
		{
			if (_rb2d == null)
				return;

			if (value)
				_rb2d.gravityScale = 1;
			else
				_rb2d.gravityScale = 0;
		}
	}
}