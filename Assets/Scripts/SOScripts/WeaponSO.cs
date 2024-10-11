using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.SOScripts
{
    [CreateAssetMenu(fileName = "WeaponSO", menuName = "WeaponSO/Weapon", order = 0)]
    public class WeaponSO : ScriptableObject
    {
        public List<WeaponList> weaponLists = new List<WeaponList>();
    }

    [Serializable]
    public class WeaponList
    {
        public string weaponName;
        public Sprite weaponSprite;
        public Sprite bulletSprite;
        public string weaponDesc;
        public int weaponPrice;
    }
}
