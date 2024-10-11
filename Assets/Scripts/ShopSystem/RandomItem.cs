using System.Collections;
using System.Collections.Generic;
using BrotatoLike.SOScripts;
using UnityEngine;

namespace BrotatoLike.Shop
{
    public class RandomItem : MonoBehaviour
    {
        public static RandomItem Instance;

        [SerializeField]
        private GameObject cardParent;
        [SerializeField]
        private GameObject itemCard;
        [SerializeField]
        private ItemSO itemSO;
        [SerializeField]
        private WeaponSO weaponSO;
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

        public void Reroll()
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
            ItemRandomize();
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
