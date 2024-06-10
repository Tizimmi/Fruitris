using Zenject;
using UnityEngine;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField]
    private GameStateHandler _gameStateHandler;

    public override void InstallBindings()
    {
    }
}
