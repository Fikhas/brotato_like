using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Wave;
using TMPro;
using UnityEngine;

namespace BrotatoLike.Shop
{
    public class GameShopConnector : MonoBehaviour
    {
        public static GameShopConnector Instance;
        [SerializeField]
        private TMP_Text waveInfo;
        [SerializeField]
        private TMP_Text coinInfo;
        [SerializeField]
        private TMP_Text goWave;
        [SerializeField]
        private TMP_Text rerollText;

        private void Awake()
        {
            Instance = this;
        }

        public void InitializeShopPanel()
        {
            waveInfo.text = $"Wave {WaveManager.Instance.currentWave} (Total {WaveManager.Instance.waveAmount})";
            goWave.text = $"Go (Wave {WaveManager.Instance.currentWave})";
            coinInfo.text = $"Coin: {CharController.Instance.model.coin}";
            rerollText.text = $"Reroll ({2 + WaveManager.Instance.currentWave} Coin)";
            RandomItem.Instance.rerollPrice = 2 + WaveManager.Instance.currentWave;
        }

        public void UpdateRerollPrice(int coin)
        {
            rerollText.text = $"Reroll ({coin} Coin)";
        }

        public void UpdateCoinInfo()
        {
            coinInfo.text = $"Coin: {CharController.Instance.model.coin}";
        }
    }
}
