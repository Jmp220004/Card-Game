using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    AudioSource _audioSource;

    //this is our 'constructor', called when this state is created
    public GameWinState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse
        _stateMachine = stateMachine;
        _controller = controller;
    }

    // play audio winning
    // Main menu
    public override void Enter()
    {
        base.Enter();
        _controller.CurrentState.text = "Win State";
        SceneManager.LoadScene("WinMenu");
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
    }
}
