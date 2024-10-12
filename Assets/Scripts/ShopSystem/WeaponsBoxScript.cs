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

        public void InitializeWeaponShop()
        {
            if (CharController.Instance.model.weaponsName.Count > 0)
            {
                for (int i = 0; i < CharController.Instance.model.weaponsName.Count; i++)
                {
                    UpdateWeapon(CharController.Instance.model.weaponsName[i]);
                }
            }
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
                            CharController.Instance.model.weaponsName.Add(weapon.weaponName);
                        }
                    }
                }
                UpdateWeaponAmount();
            }
        }

        public void UpdateWeapon(string weaponName)
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
                if (weapon.gameObject.name == "Weapon(Clone)")
                {
                    Debug.Log($"Request Weapon: {weapon.gameObject.name}");
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
