using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Pooling;
using UnityEngine;

namespace BrotatoLike.Potion
{
    public class PotionScript : MonoBehaviour
    {
        public static PotionScript Instance;

        [SerializeField]
        private ObjectPool potionObject;
        [SerializeField]
        private float dropChance;

        private void Awake()
        {
            Instance = this;
        }

        public void DropPotion(Transform potionPos)
        {
            float potionDrop = Random.Range(0f, 100f);

            if (potionDrop <= dropChance)
            {
                GameObject newPotion = potionObject.GetObject();
                newPotion.transform.position = potionPos.position;
            }
        }

        public void ReturnPotion(GameObject potion)
        {
            potionObject.ReturnObject(potion);
        }

        public void DestroyAllPotion()
        {
            Transform[] potions = gameObject.GetComponentsInChildren<Transform>();
            foreach (var potion in potions)
            {
                if (potion.gameObject.name == "Potion(Clone)")
                {
                    potionObject.ReturnObject(potion.gameObject);
                }
            }
        }
    }
}
