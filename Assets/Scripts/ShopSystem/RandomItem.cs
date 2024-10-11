using System.Collections;
using System.Collections.Generic;
using BrotatoLike.SOScripts;
using UnityEngine;

namespace BrotatoLike.Shop
{
    public class RandomItem : MonoBehaviour
    {
        [SerializeField]
        private GameObject cardParent;
        [SerializeField]
        private GameObject itemCard;
        [SerializeField]
        private ItemSO itemSO;
        [SerializeField]
        private int maxRandomItem;

        private void Awake()
        {
            ItemRandomize();
        }

        public void ItemRandomize()
        {
            for (int i = 0; i < maxRandomItem; i++)
            {
                GameObject card = Instantiate(itemCard, cardParent.transform);
                int randomNum = Random.Range(0, 4);
                ItemList item = itemSO.itemLists[randomNum];
                card.GetComponent<CardScript>().itemImg.sprite = item.itemSprite;
                card.GetComponent<CardScript>().titleText.text = item.itemName;
                card.GetComponent<CardScript>().descText.text = item.itemDescription;
                card.GetComponent<CardScript>().priceText.text = $"{item.itemPrice} Coins";
            }
        }
    }
}
