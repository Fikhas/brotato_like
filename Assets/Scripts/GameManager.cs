using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Weapon;
using UnityEngine;

public enum GameState
{
    Gameplay,
    Shop,
    Pause,
    Gameover,
    ChooseWeapon,
    GameComplete
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;

    private void Awake()
    {
        Instance = this;
        gameState = GameState.ChooseWeapon;
    }

    private void Start()
    {
        ChooseWeapon.Instance.ChooseWeaponOn();
    }
}
