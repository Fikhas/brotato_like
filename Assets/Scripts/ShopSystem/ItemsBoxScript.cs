using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoLike.Shop
{
    public class ItemsBoxScript : MonoBehaviour
    {
        public static ItemsBoxScript Instance;

        [SerializeField]
        private GameObject itemCard;
        [SerializeField]
        private TMP_Text amountText;

        private int weaponSlot;
        private int itemActiveAmount;

        private void Awake()
        {
            itemActiveAmount = 0;
            Instance = this;
        }
        public void AddItem(string itemName)
        {
            GameObject newItemCard = Instantiate(itemCard, transform);
            itemActiveAmount += 1;
            foreach (var item in RandomItem.Instance.itemSO.itemLists)
            {
                if (item.itemName == itemName)
                {
                    Image[] cardChild = newItemCard.GetComponentsInChildren<Image>();
                    foreach (var image in cardChild)
                    {
                        if (image.gameObject.name == "Image")
                        {
                            image.sprite = item.itemSprite;
                        }
                    }
                }
            }
            amountText.text = $"Items({itemActiveAmount})";
        }
    }
}
