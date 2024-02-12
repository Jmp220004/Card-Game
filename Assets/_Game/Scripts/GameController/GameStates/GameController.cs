using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem.XR;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    [SerializeField] private Unit _playerUnitPrefab;
    [SerializeField] private Unit _enemyUnitPrefab;
    [SerializeField] private Transform _playerUnitSpawnLocation;
    [SerializeField] private Transform _enemyUnitSpawnLocation;
    [SerializeField] private UnitSpawner _unitSpawner;
    [SerializeField] private InputBroadcaster _input;

    [Header("UI Dependencies")]
    [SerializeField] private TMP_Text _currentState;
    [SerializeField] private TMP_Text _player;
    [SerializeField] private HUD _playerHUD;
    [SerializeField] private HUD _enemyHUD;
    [SerializeField] private TMP_Text _enemy;

    [SerializeField] private Button _attack;
    [SerializeField] private Button _heal;

    public float TapLimitDuration => _tapLimitDuration;

    public Unit PlayerUnitPrefab => _playerUnitPrefab;
    public Unit EnemyUnitPrefab => _enemyUnitPrefab;
    public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    public Transform EnemyUnitSpawnLocation => _enemyUnitSpawnLocation;
    public UnitSpawner UnitSpawner => _unitSpawner; 

    public InputBroadcaster Input => _input;
    public TMP_Text CurrentState => _currentState;
    public TMP_Text Player => _player;
    public HUD PlayerHUD => _playerHUD;
    public TMP_Text Enemy => _enemy;
    public HUD EnemyHUD => _enemyHUD;
    public Button Attack => _attack;
    public Button Heal => _heal;


}
