using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using BrotatoLike.Shop;
using BrotatoLike.Spawn;
using TMPro;
using UnityEngine;

namespace BrotatoLike.Wave
{
    public class WaveManager : MonoBehaviour
    {
        public static WaveManager Instance;

        public int waveAmount;
        public int currentWave;
        public float waveDuration;

        [SerializeField]
        private TMP_Text durationText;
        [SerializeField]
        private TMP_Text waveAmountText;

        private float updateCD;
        private bool isSpawn;
        private float delaySpawn;
        private float bossCD;

        private void Awake()
        {
            Instance = this;
            isSpawn = false;
            updateCD = 0;
            durationText.text = $"00:{waveDuration}";
            waveAmountText.text = $"Wave: {currentWave}/{waveAmount}";
        }

        private void OnDisable()
        {
            updateCD = 0;
        }

        private void Update()
        {
            if (GameManager.Instance.gameState == GameState.Gameplay)
            {
                delaySpawn += Time.deltaTime;
                if (delaySpawn > 3)
                {
                }

                updateCD += Time.deltaTime;
                if (updateCD > 1 && waveDuration > 0)
                {
                    isSpawn = true;
                    waveDuration = waveDuration - 1;
                    durationText.text = $"00:{waveDuration}";
                    updateCD = 0;
                }

                if (waveDuration % 3 == 0)
                {
                    if (isSpawn)
                    {
                        SpawnEnemy.Instance.RandomEnemy(currentWave);
                        isSpawn = false;
                    }
                }

                if (currentWave % 5 == 0)
                {
                    bossCD += Time.deltaTime;
                    if (bossCD >= 10)
                    {
                        SpawnEnemy.Instance.SpawnSlimelegion(1);
                        bossCD = 0;
                    }
                }

                if (currentWave == 20 && waveDuration < 1)
                {
                    PauseSystem.Instance.GameComplete();
                }

                if (waveDuration < 1)
                {
                    ShopSystem.Instance.ShopActive();
                }

            }
        }

        public void StartWave()
        {
            waveDuration = 45;
            durationText.text = $"00:{waveDuration}";
            waveAmountText.text = $"Wave: {currentWave}/{waveAmount}";
        }

        public void ResetWave()
        {
            currentWave = 1;
            waveDuration = 45;
        }
    }
}
