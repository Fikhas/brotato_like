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

        private void Awake()
        {
            Instance = this;
        }
        public void AddItem(string itemName)
        {
            Transform[] itemsActive = transform.GetComponentsInChildren<Transform>();
            int itemActiveAmount = 0;
            foreach (var itemActive in itemsActive)
            {
                if (itemActive.gameObject.name.Contains("WeaponsBox"))
                {
                    continue;
                }
                if (itemActive.gameObject.name.Contains("Weapon"))
                {
                    itemActiveAmount += 1;
                }
            }

            if (itemActiveAmount < CharController.Instance.model.weaponSlot)
            {
                GameObject newItemCard = Instantiate(itemCard, transform);
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
            }
            amountText.text = $"Items({itemActiveAmount}))";
        }
    }
}
