using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Coin;
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
        public int price;

        public void BuyCard()
        {
            int coinAmount = CharController.Instance.model.coin;
            if (price <= coinAmount)
            {
                if (titleText.text == "FireStaff" || titleText.text == "IceStaff" || titleText.text == "LightningStaff")
                {
                    CharController.Instance.model.coin -= price;
                    Debug.Log("Buy Weapon, The Rest of Money is: " + CharController.Instance.model.coin);
                    RandomItem.Instance.Restock("weapon");
                    WeaponsBoxScript.Instance.AddWeapon(titleText.text);
                    GameShopConnector.Instance.UpdateCoinInfo();
                }
                else
                {
                    CharController.Instance.model.coin -= price;
                    Debug.Log("Buy Attach, The Rest of Money is: " + CharController.Instance.model.coin);
                    RandomItem.Instance.Restock("attach");
                    ItemsBoxScript.Instance.AddItem(titleText.text);
                    GameShopConnector.Instance.UpdateCoinInfo();
                }
                Destroy(gameObject);
            }
        }
    }
}
