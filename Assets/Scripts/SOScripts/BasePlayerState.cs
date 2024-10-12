using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.SOScripts
{
    [CreateAssetMenu(fileName = "BasePlayerState", menuName = "BasePlayerState")]
    public class BasePlayerState : ScriptableObject
    {
        public int moveSpeed;
        public int castingSpeed;
        public float health;
        public float maxHealth;
        public float damage;
        public float fireDamage;
        public float iceDamage;
        public float lightningDamage;
        public float critChance;
        public int weaponSlot;
        public float playerLevel;
        public float XPAmount;
        public int coin;

        public List<string> weaponsName = new List<string>();
    }
}
