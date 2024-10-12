using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Pooling;
using TMPro;
using UnityEngine;

namespace BrotatoLike.Coin
{
    public class CoinScript : MonoBehaviour
    {
        public static CoinScript Instance;

        [SerializeField]
        private ObjectPool coinPool;
        [SerializeField]
        private int coinAmount;
        [SerializeField]
        private TMP_Text coinText;

        private void Awake()
        {
            Instance = this;
            coinAmount = 0;
        }

        public void SpawnCoin(Vector2 coinPosition, float coinAmount)
        {
            for (int i = 0; i < coinAmount; i++)
            {
                GameObject coinObject = coinPool.GetObject();
                coinObject.transform.position = coinPosition;
            }
        }

        public void DestroyCoin(GameObject coinObject)
        {
            coinPool.ReturnObject(coinObject);
        }

        public void UpdateCoin(int coinToAdd)
        {
            coinAmount += coinToAdd;
            coinText.text = $"Coin: {coinAmount}";
        }

        public void ResetCoin()
        {
            coinAmount = 0;
            coinText.text = $"Coin: {coinAmount}";
        }

        public void AddCoinToPlayer()
        {
            CharController.Instance.model.coin += coinAmount;
        }

        public void DestroyAllCoin()
        {
            Transform[] coins = gameObject.GetComponentsInChildren<Transform>();
            foreach (var coin in coins)
            {
                if (coin.gameObject.name == "Coin(Clone)")
                {
                    coinPool.ReturnObject(coin.gameObject);
                }
            }
        }
    }
}
