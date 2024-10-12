using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using BrotatoLike.Character;
using BrotatoLike.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoLike.Weapon
{
    public class WeaponsBoxScript : MonoBehaviour
    {
        public static WeaponsBoxScript Instance;

        [SerializeField]
        private GameObject weaponCard;
        [SerializeField]
        private TMP_Text amountText;

        private int weaponSlot;

        private void Awake()
        {
            Instance = this;
        }

        public void AddWeapon(string weaponName)
        {
            Transform[] weaponsActive = transform.GetComponentsInChildren<Transform>();
            int weaponActiveAmount = 0;
            foreach (var weaponActive in weaponsActive)
            {
                if (weaponActive.gameObject.name.Contains("WeaponsBox"))
                {
                    continue;
                }
                if (weaponActive.gameObject.name.Contains("Weapon"))
                {
                    weaponActiveAmount += 1;
                }
            }

            if (weaponActiveAmount < CharController.Instance.model.weaponSlot)
            {
                GameObject newWeaponCard = Instantiate(weaponCard, transform);
                foreach (var weapon in RandomItem.Instance.weaponSO.weaponLists)
                {
                    if (weapon.weaponName == weaponName)
                    {
                        Image[] cardChild = newWeaponCard.GetComponentsInChildren<Image>();
                        foreach (var image in cardChild)
                        {
                            if (image.gameObject.name == "Image")
                            {
                                image.sprite = weapon.weaponSprite;
                            }
                        }
                    }
                }
            }
            amountText.text = $"Weapons({weaponActiveAmount}/{CharController.Instance.model.weaponSlot})";
        }
    }
}
