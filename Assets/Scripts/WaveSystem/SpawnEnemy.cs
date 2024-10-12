using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

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
                        enemyObject.tag = "Ghost";
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
                        enemyObject.tag = "Skullslime";
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
                        enemyObject.tag = "RedSkullslime";
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
                        enemyObject.tag = "Slimelegion";
                        enemyObject.transform.localScale = enemy.scale;
                    }
                }
            }
        }

        public void RandomEnemy(int waveNumber)
        {
            string enemyUnit = "";
            if (waveNumber % 2 == 0)
            {
                enemyUnit = "Skullslime";
            }
            else
            {
                enemyUnit = "Ghost";
            }

            int randomSizeGroup = 0;
            if (enemyUnit == "Skullslime")
            {
                randomSizeGroup = Random.Range(1 + waveNumber, 4 + waveNumber);
            }
            else
            {
                randomSizeGroup = Random.Range(4 + waveNumber, 8 + waveNumber);
            }

            int ghostChance = 70 - waveNumber;
            int skullslimeChance = 30 + waveNumber;
            for (int i = 0; i < randomSizeGroup; i++)
            {
                int randomNum = Random.Range(1, 100);
                if (randomNum < skullslimeChance)
                {
                    SpawnSkullslime(1);
                }
                else if (randomNum > skullslimeChance)
                {
                    SpawnGhost(1);
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

        public void DestroyAllEnemy()
        {
            Transform[] enemies = gameObject.GetComponentsInChildren<Transform>();
            foreach (var enemy in enemies)
            {
                if (enemy.gameObject.name != "SpawnEnemy")
                {
                    DestroyEnemy(enemy.gameObject);
                }
            }
        }
    }
}
