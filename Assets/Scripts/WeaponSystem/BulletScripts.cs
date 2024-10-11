using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Enemy;
// using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using BrotatoLike.Spawn;

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
                timer = 0;
                WeaponScript.Instance.ReturnBullet(gameObject);
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
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyScript>().SubHP(1);
                WeaponScript.Instance.ReturnBullet(gameObject);
            }
        }
    }
}
