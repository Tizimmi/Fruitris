using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    private string _name;
    [Inject]
    private LeaderBoard _scoreData;

    private void Start()
    {

    }
}
