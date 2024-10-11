using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using BrotatoLike.Enemy;
using BrotatoLike.Pooling;
using BrotatoLike.SOScripts;
using UnityEngine;

namespace BrotatoLike.Spawn
{
    public class SpawnEnemy : MonoBehaviour
    {
        public static SpawnEnemy Instance;
        public ObjectPool enemyPool;
        public EnemiesSO enemySO;

        [SerializeField]
        private float minX;
        [SerializeField]
        private float maxX;
        [SerializeField]
        private float minY;
        [SerializeField]
        private float maxY;

        private void Awake()
        {
            SpawnSkullslime(5);
            Instance = this;
        }

        public void SpawnGhost(int enemyAmount)
        {
            for (int i = 0; i < enemyAmount; i++)
            {
                GameObject enemyObject = enemyPool.GetObject();
                enemyObject.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                foreach (var enemy in enemySO.enemyLists)
                {
                    if (enemy.enemyName == "Ghost")
                    {
                        enemyObject.GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
                        enemyObject.GetComponent<EnemyScript>().speed = enemy.speed;
                        enemyObject.GetComponent<EnemyScript>().hp = enemy.hp;
                        enemyObject.GetComponent<EnemyScript>().damage = enemy.damage;
                        enemyObject.GetComponent<EnemyScript>().coin = enemy.coin;
                        enemyObject.transform.localScale = enemy.scale;
                    }
                }
            }
        }

        public void SpawnSkullslime(int enemyAmount)
        {
            for (int i = 0; i < enemyAmount; i++)
            {
                GameObject enemyObject = enemyPool.GetObject();
                enemyObject.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                foreach (var enemy in enemySO.enemyLists)
                {
                    if (enemy.enemyName == "Skullslime")
                    {
                        enemyObject.GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
                        enemyObject.GetComponent<EnemyScript>().speed = enemy.speed;
                        enemyObject.GetComponent<EnemyScript>().hp = enemy.hp;
                        enemyObject.GetComponent<EnemyScript>().damage = enemy.damage;
                        enemyObject.GetComponent<EnemyScript>().coin = enemy.coin;
                        enemyObject.transform.localScale = enemy.scale;
                    }
                }
            }
        }

        public void SpawnRedSkullslime(int enemyAmount, Vector3 spawnPos)
        {
            for (int i = 0; i < enemyAmount; i++)
            {
                GameObject enemyObject = enemyPool.GetObject();
                enemyObject.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                foreach (var enemy in enemySO.enemyLists)
                {
                    if (enemy.enemyName == "RedSkullslime")
                    {
                        enemyObject.GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
                        enemyObject.GetComponent<EnemyScript>().speed = enemy.speed;
                        enemyObject.GetComponent<EnemyScript>().hp = enemy.hp;
                        enemyObject.GetComponent<EnemyScript>().damage = enemy.damage;
                        enemyObject.GetComponent<EnemyScript>().coin = enemy.coin;
                        enemyObject.transform.localScale = enemy.scale;
                    }
                }
            }
        }

        public void SpawnSlimelegion(int enemyAmount)
        {
            for (int i = 0; i < enemyAmount; i++)
            {
                GameObject enemyObject = enemyPool.GetObject();
                enemyObject.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                foreach (var enemy in enemySO.enemyLists)
                {
                    if (enemy.enemyName == "Slimelegion")
                    {
                        enemyObject.GetComponent<SpriteRenderer>().sprite = enemy.enemySprite;
                        enemyObject.GetComponent<EnemyScript>().speed = enemy.speed;
                        enemyObject.GetComponent<EnemyScript>().hp = enemy.hp;
                        enemyObject.GetComponent<EnemyScript>().damage = enemy.damage;
                        enemyObject.GetComponent<EnemyScript>().coin = enemy.coin;
                        enemyObject.AddComponent<Slimelegion>();
                        enemyObject.transform.localScale = enemy.scale;
                    }
                }
            }
        }

        public void DestroyEnemy(GameObject objectReturn)
        {
            if (objectReturn.GetComponent<Slimelegion>() != null)
            {
                Destroy(objectReturn.GetComponent<Slimelegion>());
            }
            enemyPool.ReturnObject(objectReturn);
        }
    }
}
