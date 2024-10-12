using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.SOScripts;
using UnityEngine;

namespace BrotatoLike.Shop
{
    public class RandomItem : MonoBehaviour
    {
        public static RandomItem Instance;

        public ItemSO itemSO;
        public WeaponSO weaponSO;
        public int rerollPrice;

        [SerializeField]
        private GameObject cardParent;
        [SerializeField]
        private GameObject itemCard;
        [SerializeField]
        private int maxRandomItem;

        private void Awake()
        {
            Instance = this;
            ItemRandomize();
        }

        public void ItemRandomize()
        {
            for (int i = 0; i < maxRandomItem; i++)
            {
                GameObject card = Instantiate(itemCard, cardParent.transform);
                if (i == 0)
                {
                    int randomNumWeapon = Random.Range(0, 3);
                    WeaponList item = weaponSO.weaponLists[randomNumWeapon];
                    card.GetComponent<CardScript>().itemImg.sprite = item.weaponSprite;
                    card.GetComponent<CardScript>().titleText.text = item.weaponName;
                    card.GetComponent<CardScript>().descText.text = item.weaponDesc;
                    card.GetComponent<CardScript>().priceText.text = $"{item.weaponPrice} Coins";
                    card.GetComponent<CardScript>().price = item.weaponPrice;
                }
                else
                {
                    int randomNumItem = Random.Range(0, 5);
                    ItemList item = itemSO.itemLists[randomNumItem];
                    card.GetComponent<CardScript>().itemImg.sprite = item.itemSprite;
                    card.GetComponent<CardScript>().titleText.text = item.itemName;
                    card.GetComponent<CardScript>().descText.text = item.itemDescription;
                    card.GetComponent<CardScript>().priceText.text = $"{item.itemPrice} Coins";
                    card.GetComponent<CardScript>().price = item.itemPrice;
                }
            }
        }

        public void Reroll()
        {
            if (rerollPrice < CharController.Instance.model.coin)
            {
                Transform[] cardInstances = cardParent.GetComponentsInChildren<Transform>();
                foreach (var item in cardInstances)
                {
                    if (item.gameObject.name == "ItemCards")
                    {
                        continue;
                    }
                    Destroy(item.gameObject);
                }
                CharController.Instance.model.coin -= rerollPrice;
                GameShopConnector.Instance.UpdateRerollPrice(2 * rerollPrice);
                rerollPrice = 2 * rerollPrice;
                ItemRandomize();
                GameShopConnector.Instance.UpdateCoinInfo();
            }
        }

        public void Restock(string restockItem)
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject card = Instantiate(itemCard, cardParent.transform);
                if (restockItem == "weapon")
                {
                    int randomNumWeapon = Random.Range(0, 2);
                    WeaponList item = weaponSO.weaponLists[randomNumWeapon];
                    card.GetComponent<CardScript>().itemImg.sprite = item.weaponSprite;
                    card.GetComponent<CardScript>().titleText.text = item.weaponName;
                    card.GetComponent<CardScript>().descText.text = item.weaponDesc;
                    card.GetComponent<CardScript>().priceText.text = $"{item.weaponPrice} Coins";
                }
                else
                {
                    int randomNumItem = Random.Range(0, 4);
                    ItemList item = itemSO.itemLists[randomNumItem];
                    card.GetComponent<CardScript>().itemImg.sprite = item.itemSprite;
                    card.GetComponent<CardScript>().titleText.text = item.itemName;
                    card.GetComponent<CardScript>().descText.text = item.itemDescription;
                    card.GetComponent<CardScript>().priceText.text = $"{item.itemPrice} Coins";
                }
            }
        }
    }
}
