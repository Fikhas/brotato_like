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
        private int weaponActiveAmount = 0;

        private void Awake()
        {
            weaponActiveAmount = 0;
            Instance = this;
        }

        public void AddWeapon(string weaponName)
        {
            if (weaponActiveAmount < CharController.Instance.model.weaponSlot)
            {
                GameObject newWeaponCard = Instantiate(weaponCard, transform);
                weaponActiveAmount += 1;
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
                            image.GetComponentInParent<Transform>().gameObject.tag = weapon.weaponName;
                        }
                    }
                }
                UpdateWeaponAmount();
            }
        }

        public void AssignWeapon()
        {
            Transform[] weapons = gameObject.GetComponentsInChildren<Transform>();
            foreach (var weapon in weapons)
            {
                if (weapon.gameObject.name != "WeaponBox")
                {
                    WeaponSystem.Instance.SetWeapon(weapon.gameObject.tag);
                }
            }
        }

        public void UpdateWeaponAmount()
        {
            amountText.text = $"Weapons({weaponActiveAmount}/{CharController.Instance.model.weaponSlot})";
        }
    }
}
