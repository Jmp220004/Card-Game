using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    //this is our 'constructor', called when this state is created
    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        // Start
        base.Enter();
        _controller.StateChange.Play();
        Debug.Log("State: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");
        _controller.CurrentState.text = "Setup State";
        _controller.UnitSpawner.Spawn(_controller.PlayerUnitPrefab,
            _controller.PlayerUnitSpawnLocation);
        _controller.Player.text = "Agent Player";
        _controller.PlayerHUD.SetHUD(_controller.PlayerUnitPrefab);

        //Enemy
        _controller.UnitSpawner.Spawn(_controller.EnemyUnitPrefab,
            _controller.EnemyUnitSpawnLocation);
        _controller.Enemy.text = "Cheeseburger";
        _controller.EnemyHUD.SetHUD(_controller.EnemyUnitPrefab);

        _controller.EnemyUnitPrefab.currentHP = _controller.EnemyUnitPrefab.maxHP;
        _controller.PlayerUnitPrefab.currentHP = _controller.PlayerUnitPrefab.maxHP;

    }
    IEnumerator Setup()
    {
        yield return new WaitForSeconds(2f);
        _stateMachine.ChangeState(_stateMachine.PlayState);
    }

    // Stop
    public override void Exit()
    {
        base.Exit();
    }

    //Fixed Update
    public override void FixedTick()
    {
        base.FixedTick();
    }

    //Update
    public override void Tick()
    {
        base.Tick();
        _controller.StartCoroutine(Setup());    
    }
}
