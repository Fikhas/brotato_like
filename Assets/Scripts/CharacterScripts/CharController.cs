using System.Collections;
using System.Collections.Generic;
using BrotatoLike.SOScripts;

// using System.Numerics;
using BrotatoLike.Weapon;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoLike.Character
{
    [RequireComponent(typeof(CharModel), typeof(CharView))]
    public class CharController : MonoBehaviour
    {
        public static CharController Instance;

        [SerializeField]
        private Rigidbody2D rb;
        [SerializeField]
        private Slider slider;
        [SerializeField]
        private TMP_Text healthText;

        [HideInInspector]
        public CharModel model;
        [HideInInspector]
        public CharView view;
        private float horizontalInput;
        private float verticalInput;
        private float manualShootCD;

        private void Awake()
        {
            model = GetComponent<CharModel>();
            view = GetComponent<CharView>();
            Instance = this;
            InitializeHPSlider();
        }

        private void InitializeHPSlider()
        {
            healthText.text = $"HP: {model.health}";
            slider.maxValue = model.health;
            slider.value = model.health;
        }

        private void Update()
        {
            if (GameManager.Instance.gameState == GameState.Gameplay)
            {
                manualShootCD += Time.deltaTime;
                if (Input.GetMouseButton(0))
                {
                    if (manualShootCD > 0.2)
                    {
                        ManualShoot(Input.mousePosition);
                        manualShootCD = 0;
                    }
                }

                horizontalInput = Input.GetAxis("Horizontal");
                verticalInput = Input.GetAxis("Vertical");

                rb.velocity = new Vector2(horizontalInput * model.moveSpeed, verticalInput * model.moveSpeed);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }

        public GameObject NearestWeapon(Vector3 enemyPos)
        {
            GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");

            List<Transform> weaponPositions = new List<Transform>();

            foreach (var weapon in weapons)
            {
                weaponPositions.Add(weapon.transform);
            }

            GameObject weaponOn = null;
            float nearestDistance = 99999999;

            foreach (var weaponPos in weaponPositions)
            {
                if (weaponOn != null)
                {
                    float distance = Vector3.Distance(weaponPos.position, enemyPos);
                    distance = Mathf.Abs(distance);
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        weaponOn = weaponPos.gameObject;
                    }
                }
                else
                {
                    float distance = Vector3.Distance(weaponPos.position, enemyPos);
                    distance = Mathf.Abs(distance);
                    nearestDistance = distance;
                    weaponOn = weaponPos.gameObject;
                }
            }

            return weaponOn;
        }

        public List<GameObject> UnfireWeapon()
        {
            GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
            List<GameObject> unfireWeapons = new List<GameObject>();

            foreach (var weapon in weapons)
            {
                if (weapon.GetComponentInParent<WeaponScript>().isUnfire == true)
                {
                    unfireWeapons.Add(weapon);
                }
            }

            return unfireWeapons;
        }

        public void AutoShoot(Vector3 enemyPos)
        {
            GameObject nearWeapon = NearestWeapon(enemyPos);
            nearWeapon.GetComponentInParent<WeaponScript>().direction = enemyPos - nearWeapon.transform.position;
            nearWeapon.GetComponentInParent<WeaponScript>().isFollowMouse = false;
            nearWeapon.GetComponentInParent<WeaponScript>().AutoShoot(enemyPos);
            List<GameObject> unfireWeapons = UnfireWeapon();
            if (unfireWeapons.Count > 0)
            {
                foreach (var unfireWeapon in unfireWeapons)
                {
                    unfireWeapon.GetComponentInParent<WeaponScript>().isFollowMouse = false;
                    unfireWeapon.GetComponentInParent<WeaponScript>().AutoShoot(enemyPos);
                    unfireWeapon.GetComponentInParent<WeaponScript>().direction = enemyPos - nearWeapon.transform.position;
                }
            }
        }

        public void ManualShoot(Vector3 mousePosition)
        {
            GameObject nearWeapon = NearestWeapon(mousePosition);
            nearWeapon.GetComponentInParent<WeaponScript>().isFollowMouse = true;
            nearWeapon.GetComponentInParent<WeaponScript>().isCanShoot = true;
            List<GameObject> unfireWeapons = UnfireWeapon();
            if (unfireWeapons.Count > 0)
            {
                foreach (var unfireWeapon in unfireWeapons)
                {
                    unfireWeapon.GetComponentInParent<WeaponScript>().isFollowMouse = true;
                    unfireWeapon.GetComponentInParent<WeaponScript>().isCanShoot = true;
                    unfireWeapon.GetComponentInParent<WeaponScript>().direction = mousePosition - nearWeapon.transform.position;
                }
            }
        }

        public void AddHP(float hpToAdd)
        {
            model.health += hpToAdd;
            if (model.health > model.maxHealth)
            {
                model.health = 10;
            }
            slider.value = model.health;
            healthText.text = $"HP: {model.health}";
        }

        public void SubHP(float hpToSub)
        {

            model.health -= hpToSub;
            slider.value = model.health;
            healthText.text = $"HP: {model.health}";
            if (model.health < 1)
            {
                PauseSystem.Instance.Gameover();
            }
        }

        public void UpdateHP()
        {
            model.health = model.maxHealth;
            slider.maxValue = model.maxHealth;
            slider.value = model.health;
        }

        public void ResetPlayerState()
        {
            BasePlayerState basePlayerState = model.basePlayerState;
            model.moveSpeed = basePlayerState.moveSpeed;
            model.castingSpeed = basePlayerState.castingSpeed;
            model.health = basePlayerState.health;
            model.maxHealth = basePlayerState.maxHealth;
            model.damage = basePlayerState.damage;
            model.fireDamage = basePlayerState.fireDamage;
            model.iceDamage = basePlayerState.iceDamage;
            model.lightningDamage = basePlayerState.lightningDamage;
            model.critChance = basePlayerState.critChance;
            model.weaponSlot = basePlayerState.weaponSlot;
            model.playerLevel = basePlayerState.playerLevel;
            model.XPAmount = basePlayerState.XPAmount;
            model.coin = basePlayerState.coin;
            model.weaponsName = basePlayerState.weaponsName;
        }
    }
}
