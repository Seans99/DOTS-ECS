using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
public partial class PlayerInputSystem : SystemBase
{
    private GameInput _inputActions;
    private Entity _player;

    protected override void OnCreate()
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerMoveInput>();

        _inputActions = new GameInput();
    }

    protected override void OnStartRunning()
    {
        _inputActions.Enable();
        _inputActions.Gameplay.Fire.performed += OnFire;
        _player = SystemAPI.GetSingletonEntity<PlayerTag>();
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        if (!SystemAPI.Exists(_player))
        {
            return;
        }

        SystemAPI.SetComponentEnabled<FireBulletTag>(_player, true);
    }

    protected override void OnUpdate()
    {
        Vector2 moveInput = _inputActions.Gameplay.Move.ReadValue<Vector2>();

        SystemAPI.SetSingleton(new PlayerMoveInput { _value = moveInput });
    }

    protected override void OnStopRunning()
    {
        _inputActions.Disable();
        _player = Entity.Null;
    }
}
