using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using BrotatoLike.Weapon;
using Unity.VisualScripting;
using UnityEngine;

namespace BrotatoLike.Character
{
    [RequireComponent(typeof(CharModel), typeof(CharView))]
    public class CharController : MonoBehaviour
    {
        public static CharController Instance;

        [SerializeField]
        private Rigidbody2D rb;

        private CharModel model;
        private CharView view;
        private float horizontalInput;
        private float verticalInput;
        private float manualShootCD;

        private void Awake()
        {
            model = GetComponent<CharModel>();
            view = GetComponent<CharView>();
            Instance = this;
        }

        private void Update()
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

        public GameObject NearestWeapon(Vector3 enemyPos)
        {
            GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
            GameObject weaponOn = null;
            float nearestDistance = 99999999;

            foreach (var weapon in weapons)
            {
                if (weaponOn != null)
                {
                    float distance = Vector3.Distance(weapon.transform.position, enemyPos);
                    distance = Mathf.Abs(distance);
                    Debug.Log($"Weapon: {weapon}, the distance is {distance}");
                    if (distance < nearestDistance)
                    {
                        nearestDistance = distance;
                        weaponOn = weapon;
                    }
                }
                else
                {
                    float distance = Vector3.Distance(weapon.transform.position, enemyPos);
                    distance = Mathf.Abs(distance);
                    Debug.Log($"Weapon: {weapon}, the distance is {distance}");
                    nearestDistance = distance;
                    weaponOn = weapon;
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
                if (weapon.GetComponent<WeaponScript>().isUnfire == true)
                {
                    unfireWeapons.Add(weapon);
                }
            }

            return unfireWeapons;
        }

        public void AutoShoot(Vector3 enemyPos)
        {
            GameObject nearWeapon = NearestWeapon(enemyPos);
            nearWeapon.GetComponent<WeaponScript>().direction = enemyPos - nearWeapon.transform.position;
            nearWeapon.GetComponent<WeaponScript>().isFollowMouse = false;
            nearWeapon.GetComponent<WeaponScript>().AutoShoot(enemyPos);
            List<GameObject> unfireWeapons = UnfireWeapon();
            if (unfireWeapons.Count > 0)
            {
                foreach (var unfireWeapon in unfireWeapons)
                {
                    unfireWeapon.GetComponent<WeaponScript>().AutoShoot(enemyPos);
                }
            }
        }

        public void ManualShoot(Vector3 mousePosition)
        {
            GameObject nearWeapon = NearestWeapon(mousePosition);
            nearWeapon.GetComponent<WeaponScript>().isFollowMouse = true;
            nearWeapon.GetComponent<WeaponScript>().isCanShoot = true;
            List<GameObject> unfireWeapons = UnfireWeapon();
            if (unfireWeapons.Count > 0)
            {
                foreach (var unfireWeapon in unfireWeapons)
                {
                    unfireWeapon.GetComponent<WeaponScript>().isFollowMouse = true;
                    unfireWeapon.GetComponent<WeaponScript>().isCanShoot = true;
                }
            }
        }
    }
}
