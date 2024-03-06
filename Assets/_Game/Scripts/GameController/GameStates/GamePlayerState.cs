using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    public bool dead, playerTurn;

    public GamePlayerState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }


    public override void Enter()
    {
        base.Enter();
        _controller.StateChange.Play();
        _controller.Dialogue.text = "Chose an action:";
        Debug.Log("State: Game Play");
        Debug.Log("Display Player HUD");
        _controller.Attack.enabled = true;
        _controller.Heal.enabled = true;
        _controller.CurrentState.text = "Player Turn State";
        _controller.Attack.onClick.AddListener(Attack);
        _controller.Heal.onClick.AddListener(Healing);
    }

    void Attack()
    {
        if (_controller.Input.IsTapPressed == true)
        {
            dead = _controller.EnemyUnitPrefab.TakeDamage(_controller.PlayerUnitPrefab.damage);
            _controller.EnemyHUD.SetHP(_controller.EnemyUnitPrefab.currentHP);
            _controller.Dialogue.text = "Player Attacks!";
            Debug.Log("Enemy Health: " + _controller.EnemyUnitPrefab.currentHP);
            _controller.Damage.Play();
            playerTurn = true;
        }

    }

    void Healing()
    {
        _controller.PlayerUnitPrefab.Heal(5);
        _controller.PlayerHUD.SetHP(_controller.PlayerUnitPrefab.currentHP);
        _controller.Dialogue.text = "Player Heals!";
        _controller.HealSound.Play();
        playerTurn = true;
    }

    public override void Exit()
    {
        base.Exit();
        _controller.Attack.onClick.RemoveAllListeners();
        _controller.Heal.onClick.RemoveAllListeners();
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
            Debug.Log("You Win!");
            _controller.Dialogue.text = "You won the battle";
            _controller.Attack.enabled = false;
            _controller.Heal.enabled = false;
            _stateMachine.ChangeState(_stateMachine.WinState);
        }
        else if(!dead && playerTurn)
        {
            _controller.Attack.enabled = false;
            _controller.Heal.enabled = false;
            Debug.Log("Enemy Turn");
            _stateMachine.ChangeState(_stateMachine.EnemyState);
            playerTurn=false;
        }


        
    }

}
