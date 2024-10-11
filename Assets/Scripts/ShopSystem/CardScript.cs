using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Weapon;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoLike.Shop
{
    public class CardScript : MonoBehaviour
    {
        public Image itemImg;
        public TMP_Text titleText;
        public TMP_Text descText;
        public TMP_Text priceText;

        public void BuyCard()
        {
            // CharController
            if (titleText.text == "FireStaff" || titleText.text == "IceStaff" || titleText.text == "LightningStaff")
            {
                RandomItem.Instance.Restock("weapon");
                WeaponsBoxScript.Instance.AddWeapon(titleText.text);
            }
            else
            {
                RandomItem.Instance.Restock("attach");
            }
            Destroy(gameObject);
        }
    }
}
