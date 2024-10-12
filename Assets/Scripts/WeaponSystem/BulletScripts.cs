using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Enemy;
// using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using BrotatoLike.Spawn;
using BrotatoLike.SOScripts;

namespace BrotatoLike.Weapon
{
    public class BulletScripts : MonoBehaviour
    {
        public static BulletScripts Instance;

        [SerializeField]
        private float moveSpeed;

        private Rigidbody2D rb;
        private float timer;
        private Vector2 direction;
        private bool isBulletMove;


        private void Awake()
        {
            Instance = this;
            timer = 0;
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnDisable()
        {
            isBulletMove = false;
        }

        private void Update()
        {
            if (isBulletMove)
            {
                rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            }

            timer += Time.deltaTime;
            if (timer > 3)
            {
                WeaponScript.Instance.ReturnBullet(gameObject);
                timer = 0;
            }

            gameObject.GetComponent<BoxCollider2D>().size = gameObject.GetComponent<SpriteRenderer>().bounds.size;
            gameObject.GetComponent<BoxCollider2D>().offset = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.center;
        }

        public void BulletDirect(Vector3 currentDirect)
        {
            direction = currentDirect;
            direction = direction.normalized;
            isBulletMove = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ghost") || other.CompareTag("Skullslime") || other.CompareTag("RedSkullslime") || other.CompareTag("Slimelegion"))
            {
                if (gameObject.tag == "FireStaff")
                {
                    FireAttack(other.gameObject);
                }
                else if (gameObject.tag == "IceStaff")
                {
                    IceAttack(other.gameObject);
                }
                else if (gameObject.tag == "LightningStaff")
                {
                    LightningAttack(other.gameObject);
                }
                other.GetComponent<EnemyScript>().SubHP(1);
                WeaponScript.Instance.ReturnBullet(gameObject);
            }
        }

        private void FireAttack(GameObject target)
        {
            WeaponList currentWeapon = null;
            foreach (var weapon in WeaponSystem.Instance.weaponSO.weaponLists)
            {
                if (weapon.weaponName == "FireStaff")
                {
                    currentWeapon = weapon;
                }
            }
            int totalDamage = currentWeapon.baseDamage + Mathf.RoundToInt(currentWeapon.baseDamage * currentWeapon.multiplierPercent);

            Collider[] hitColliders = Physics.OverlapSphere(target.transform.position, currentWeapon.areaDamageRadius);
            foreach (Collider hit in hitColliders)
            {
                EnemyScript enemy = hit.GetComponent<EnemyScript>();
                if (enemy != null)
                {
                    enemy.SubHP(totalDamage);
                }
            }
        }

        private void IceAttack(GameObject target)
        {
            WeaponList currentWeapon = null;
            foreach (var weapon in WeaponSystem.Instance.weaponSO.weaponLists)
            {
                if (weapon.weaponName == "FireStaff")
                {
                    currentWeapon = weapon;
                }
            }

            int totalDamage = currentWeapon.baseDamage + Mathf.RoundToInt(currentWeapon.baseDamage * currentWeapon.multiplierPercent);

            EnemyScript enemy = target.GetComponent<EnemyScript>();
            EnemyWalk enemyWalk = target.GetComponent<EnemyWalk>();
            if (enemy != null)
            {
                enemy.SubHP(totalDamage);
                enemyWalk.SlowMove(currentWeapon.slowDuration);
            }
        }

        private void LightningAttack(GameObject target)
        {
            WeaponList currentWeapon = null;
            foreach (var weapon in WeaponSystem.Instance.weaponSO.weaponLists)
            {
                if (weapon.weaponName == "FireStaff")
                {
                    currentWeapon = weapon;
                }
            }

            int totalDamage = currentWeapon.baseDamage + Mathf.RoundToInt(currentWeapon.baseDamage * currentWeapon.multiplierPercent);

            Collider[] hitColliders = Physics.OverlapSphere(target.transform.position, currentWeapon.areaDamageRadius);
            foreach (Collider hit in hitColliders)
            {
                EnemyScript enemy = hit.GetComponent<EnemyScript>();
                if (enemy != null)
                {
                    bool isCritical = Random.value * 100f < currentWeapon.critChance;
                    int finalDamage = isCritical ? totalDamage * 2 : totalDamage;

                    enemy.SubHP(finalDamage);
                }
            }
        }
    }
}
