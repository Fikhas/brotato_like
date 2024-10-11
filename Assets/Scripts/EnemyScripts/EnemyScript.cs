using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Coin;
using BrotatoLike.Spawn;
using BrotatoLike.Weapon;
using UnityEngine;

namespace BrotatoLike.Enemy
{
    public class EnemyScript : MonoBehaviour
    {
        public static EnemyScript Instance;

        public float hp;
        public float damage;
        public float speed;
        public float coin;

        private GameObject player;
        private float timer;

        private void Awake()
        {
            Instance = this;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            distance = Mathf.Abs(distance);

            timer += Time.deltaTime;
            if (distance < 5)
            {
                if (timer > 0.2)
                {
                    player.GetComponent<CharController>().AutoShoot(gameObject.transform.position);
                    timer = 0;
                }
            }

            gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().bounds.size;
            gameObject.GetComponent<BoxCollider2D>().offset = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.center;
        }

        public void AddHP(float hpAdd)
        {
            hp += hpAdd;
            UpdateHP();
        }

        public void SubHP(float hpSub)
        {
            hp -= hpSub;
            UpdateHP();
        }

        public void UpdateHP()
        {
            if (hp < 1)
            {
                CoinScript.Instance.SpawnCoin(transform.position, 3);
                SpawnEnemy.Instance.DestroyEnemy(gameObject);
            }
        }
    }
}

