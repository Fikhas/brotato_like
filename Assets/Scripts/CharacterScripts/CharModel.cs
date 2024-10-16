using System.Collections;
using System.Collections.Generic;
using BrotatoLike.SOScripts;
using UnityEngine;

namespace BrotatoLike.Character
{
    public class CharModel : MonoBehaviour
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

        public BasePlayerState basePlayerState;
    }
}
