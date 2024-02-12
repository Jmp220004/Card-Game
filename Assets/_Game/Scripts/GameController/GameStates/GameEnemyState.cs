using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnemyState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    public bool dead, enemyTurn;


    //this is our 'constructor', called when this state is created
    public GameEnemyState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();
        _controller.CurrentState.text = "Enemy Turn State";
        dead = _controller.PlayerUnitPrefab.TakeDamage(_controller.EnemyUnitPrefab.damage);
        Debug.Log("Player Health: " + _controller.PlayerUnitPrefab.currentHP);
        _controller.PlayerHUD.SetHP(_controller.PlayerUnitPrefab.currentHP);
        enemyTurn = true;
    }

    IEnumerator Fight()
    {
        yield return new WaitForSeconds(1f);
        _stateMachine.ChangeState(_stateMachine.PlayState);
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        if (dead)
        {
            Debug.Log("You Lose!");
            _stateMachine.ChangeState(_stateMachine.LoseState);
        }
        else if(!dead && enemyTurn)
        {
            _controller.StartCoroutine(Fight());
            enemyTurn = false;
        }
    }
}