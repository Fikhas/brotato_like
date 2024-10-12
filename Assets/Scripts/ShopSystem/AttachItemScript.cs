using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using UnityEngine;

namespace BrotatoLike.Shop
{
    public class AttachItemScript : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(gameObject.tag);
            switch (gameObject.tag)
            {
                case "BearHead":
                    CharController.Instance.model.health += 1;
                    CharController.Instance.model.maxHealth += 1;
                    break;
                case "DemonHead":
                    CharController.Instance.model.damage = CharController.Instance.model.damage * (1 + (2f / 100f));
                    break;
                case "ElfHead":
                    CharController.Instance.model.castingSpeed += 1;
                    CharController.Instance.model.damage -= 1;
                    break;
                case "WolfLeg":
                    CharController.Instance.model.moveSpeed += 1;
                    break;
                case "OrcHead":
                    CharController.Instance.model.weaponSlot += 1;
                    CharController.Instance.model.moveSpeed -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}
