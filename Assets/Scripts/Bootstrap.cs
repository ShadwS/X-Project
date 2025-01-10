using UnityEngine;
using Leopotam.Ecs;
using Voody.UniLeo;
using Core.Movement;
using Core.MouseLook;

public class Bootstrap : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new ();
        _systems = new(_world);

        _systems.ConvertScene();

        AddSystems();
        AddOneFrame();

        _systems.Init();
    }

    private void Update() => _systems.Run();

    private void OnDestroy()
    {
        if (_systems == null) return;

        _systems.Destroy();
        _systems = null;

        _world.Destroy();
        _world = null;
    }

    private void AddSystems()
    {
        _systems.Add(new CursorDisableSystem());
        _systems.Add(new PlayerMouseLookSystem());

        _systems.Add(new PlayerButtonJumpPressSystem());
        _systems.Add(new PlayerJumpSystem());
        _systems.Add(new PlayerGravitySystem());
        _systems.Add(new PlayerMovementSystem());
    }

    private void AddOneFrame()
    {
        _systems.OneFrame<JumpEvent>();
    }
}