using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.SOScripts;
using UnityEngine;

namespace BrotatoLike.Weapon
{
    public class WeaponSystem : MonoBehaviour
    {
        public static WeaponSystem Instance;

        public List<GameObject> weaponPlaces;
        public WeaponSO weaponSO;

        private void Awake()
        {
            Instance = this;

            foreach (var weaponPlace in weaponPlaces)
            {
                weaponPlace.tag = "Weapon";
                weaponPlace.SetActive(false);
            }
        }

        public void SetWeapon(string weaponName)
        {
            foreach (var weaponPlace in weaponPlaces)
            {
                if (!weaponPlace.activeInHierarchy)
                {
                    foreach (var weapon in weaponSO.weaponLists)
                    {
                        if (weapon.weaponName == weaponName)
                        {
                            weaponPlace.GetComponent<SpriteRenderer>().sprite = weapon.weaponSprite;
                            weaponPlace.tag = $"{weapon.weaponName}";
                            weaponPlace.SetActive(true);
                            CharController.Instance.model.weaponsName.Add(weapon.weaponName);
                            return;
                        }
                    }
                }
            }
        }

        public void WeaponOff()
        {
            foreach (var weaponPlace in weaponPlaces)
            {
                weaponPlace.SetActive(false);
            }
        }
    }
}
