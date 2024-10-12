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

        public void SpawnCoin(Vector2 coinPosition, int coinAmount)
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
            CharController.Instance.model.coin += coinAmount;
        }
    }
}
