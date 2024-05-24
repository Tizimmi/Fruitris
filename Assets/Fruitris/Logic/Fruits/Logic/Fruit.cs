using System.Collections;
using UnityEngine;
using Zenject;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    private int _value;
    [SerializeField]
    private Rigidbody2D _rb2d;
    [SerializeField]
    private Object _prefabReference;
    [SerializeField]
    private float _invunerabilityTimer;

    [Inject]
    private readonly Spawner _spawner;
    [Inject]
    private readonly ScoreView _scoreView;

    private static CollisionInfoCollection _collisions = new();
    private bool _canFinish = false;

    public IEnumerator Timer()
    {
        while (_invunerabilityTimer > 0)
        {
            _invunerabilityTimer -= Time.deltaTime;
            yield return null;
        }
        _canFinish = true;
    }
    public void ChangeIsGravitational(bool value)
    {
        if (_rb2d == null)
        {
            return;
        }
        if (value)
        {
            _rb2d.gravityScale = 1;
        }
        else
        {
            _rb2d.gravityScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != gameObject.tag)
        {
            return;
        }
        Fruit secondFruit = collision.gameObject.GetComponent<Fruit>();
        if (_collisions.Contains(secondFruit) || _collisions.Contains(this))
        {
            return;
        }
        _collisions.AddItemInCollection(this, secondFruit);
        Vector3 spawnPoint = new();
        foreach (ContactPoint2D contactPoint in collision.contacts)
        {
            Vector2 hitPoint = contactPoint.point;
            spawnPoint = new Vector3(hitPoint.x, hitPoint.y, 0);
        }

        if (int.Parse(gameObject.tag) < _spawner.fruits.Count - 1)
        {
            Merge(collision.gameObject, gameObject, spawnPoint);
        }
        _scoreView.UpdateCurrentScore(_value);
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    private void Merge(GameObject fruitA, GameObject fruitB, Vector2 position) // ������� MergeFruitStrategy
    {
        _spawner.SpawnFruit(int.Parse(fruitA.tag), position);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_canFinish && other.gameObject.CompareTag("GameOverTrigger"))
        {
            print("YOU LOSE");
        }
    }
}
