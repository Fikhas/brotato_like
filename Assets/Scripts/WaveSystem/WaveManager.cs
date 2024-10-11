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
        [SerializeField]
        private int waveAmount;
        [SerializeField]
        private float waveDuration;
        [SerializeField]
        private int currentWave;
        [SerializeField]
        private TMP_Text durationText;
        [SerializeField]
        private TMP_Text waveAmountText;

        private float updateCD;
        private bool isSpawn;
        private float bossCD;
        private bool isWaveRunning;

        private void Awake()
        {
            isSpawn = false;
            isWaveRunning = true;
            updateCD = 0;
            durationText.text = $"00:{waveDuration}";
            waveAmountText.text = $"Wave: {currentWave}/{waveAmount}";
        }

        private void OnDisable()
        {
            isWaveRunning = true;
        }

        private void Update()
        {
            if (isWaveRunning)
            {
                updateCD += Time.deltaTime;
            }
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
                    SpawnEnemy.Instance.SpawnSkullslime(5);
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

            if (waveDuration == 0)
            {
                ShopController.Instance.ShopAppear();
                isWaveRunning = false;
            }

        }
    }
}
