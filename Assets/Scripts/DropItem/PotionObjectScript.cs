using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using UnityEngine;

namespace BrotatoLike.Potion
{
    public class PotionObjectScript : MonoBehaviour
    {
        [SerializeField]
        private int addHP;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<CharController>().AddHP(addHP);
                PotionScript.Instance.ReturnPotion(gameObject);
            }
        }
    }
}
