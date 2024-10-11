using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.Character
{
    public class CharModel : MonoBehaviour
    {
        public int moveSpeed;

        [SerializeField]
        private int health;
        [SerializeField]
        private int castingSpeed;
        [SerializeField]
        private float damage;
        [SerializeField]
        private float fireDamage;
        [SerializeField]
        private float iceDamage;
        [SerializeField]
        private float lightningDamage;
        [SerializeField]
        private float critChance;
        [SerializeField]
        private int weaponSlot;
    }
}
