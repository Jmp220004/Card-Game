using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    private GameController _controller;


    // state variable here
    public GameSetupState SetupState { get; private set; }
    public GamePlayerState PlayState { get; private set; }
    public GameEnemyState EnemyState { get; private set; }
    public GameWinState WinState { get; private set; }
    public GameLoseState LoseState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        // state instatntiation here
        SetupState = new GameSetupState(this, _controller);
        PlayState = new GamePlayerState(this, _controller);
        EnemyState = new GameEnemyState(this, _controller);
        WinState = new GameWinState(this, _controller);
        LoseState = new GameLoseState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}

