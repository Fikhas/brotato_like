using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Pooling;
using Unity.VisualScripting;
using UnityEngine;

namespace BrotatoLike.Weapon
{
    public class WeaponScript : MonoBehaviour
    {
        public Vector3 direction;
        public Vector3 mousePosition;
        public float currentRot;

        public static WeaponScript Instance;

        [SerializeField]
        private ObjectPool bullet;
        [SerializeField]
        private Transform bulletPos;

        private float timer;
        private float autoShootTimer;
        public bool isCanShoot;
        private bool isCanAutoShoot;
        private float notFollowMouseCD;
        public bool isUnfire;
        public bool isFollowMouse;

        private void Awake()
        {
            isFollowMouse = true;
            Instance = this;
            isCanShoot = true;
            isUnfire = false;
        }

        private void Update()
        {
            if (isFollowMouse)
            {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                direction = mousePosition - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                currentRot = angle;

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            }
            else
            {
                notFollowMouseCD += Time.deltaTime;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                currentRot = angle;

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

                if (notFollowMouseCD > 1)
                {
                    isFollowMouse = true;
                    notFollowMouseCD = 0;
                }
            }

            if (isCanShoot)
            {
                isUnfire = false;
                GameObject bulletActive = bullet.GetObject();
                bulletActive.GetComponent<BulletScripts>().BulletDirect(DirectObsScript.Instance.direction);
                bulletActive.transform.rotation = Quaternion.Euler(new Vector3(0, 0, DirectObsScript.Instance.currentRot - 90));
                bulletActive.transform.position = bulletPos.position;
                isCanShoot = false;
            }

            // if (!isCanShoot)
            // {
            //     timer += Time.deltaTime;
            //     if (timer > 0.2)
            //     {
            //         isCanShoot = true;
            //         isUnfire = true;
            //         timer = 0;
            //     }
            // }

            autoShootTimer += Time.deltaTime;
            if (autoShootTimer > 0.2)
            {
                isCanAutoShoot = true;
                isUnfire = true;
                autoShootTimer = 0;
            }
        }

        public void AutoShoot(Vector3 targetObj)
        {
            if (isCanAutoShoot)
            {
                isUnfire = false;
                Vector3 direction = targetObj - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                float currentRot = angle;

                GameObject bulletActive = bullet.GetObject();
                bulletActive.GetComponent<BulletScripts>().BulletDirect(direction);
                bulletActive.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentRot - 90));
                bulletActive.transform.position = bulletPos.position;
                isCanAutoShoot = false;
            }
        }

        public void ReturnBullet(GameObject bulletObject)
        {
            bullet.ReturnObject(bulletObject);
        }
    }
}
