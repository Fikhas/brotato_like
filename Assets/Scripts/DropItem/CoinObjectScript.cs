using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using UnityEngine;

namespace BrotatoLike.Coin
{
    public class CoinObjectScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                XPSystem.Instance.UpdateXP(1);
                CoinScript.Instance.UpdateCoin(1);
                CoinScript.Instance.DestroyCoin(gameObject);
            }
        }
    }
}
