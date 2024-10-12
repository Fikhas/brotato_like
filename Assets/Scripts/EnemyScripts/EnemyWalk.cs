using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Enemy;
using BrotatoLike.Spawn;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public static EnemyWalk Instance;

    private GameObject player;

    private bool isSlowMove;
    private bool isSubSpeed;
    private float slowDuration;
    private float timer;

    private void Awake()
    {
        Instance = this;
        slowDuration = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.Gameplay)
        {
            if (isSubSpeed)
            {
                gameObject.GetComponent<EnemyScript>().speed -= 2;
                isSubSpeed = false;
            }

            if (isSlowMove)
            {
                timer += Time.deltaTime;
                if (timer > slowDuration)
                {
                    isSlowMove = false;
                    MoveNormalize(2);
                    timer = 0;
                }
            }
            gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, gameObject.GetComponent<EnemyScript>().speed * Time.deltaTime);
        }
    }

    public void SlowMove(float slowDuration)
    {
        isSlowMove = true;
        isSubSpeed = true;
        this.slowDuration = slowDuration;
    }

    public void MoveNormalize(int slowAmount)
    {
        gameObject.GetComponent<EnemyScript>().speed += slowAmount;
    }
}
