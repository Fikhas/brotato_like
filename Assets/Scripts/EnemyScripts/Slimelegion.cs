using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Spawn;
using UnityEngine;

namespace BrotatoLike.Enemy
{
    public class Slimelegion : MonoBehaviour
    {
        private float redSkullslimeCD;

        private void Awake()
        {
            redSkullslimeCD = 0;
        }

        private void OnDisable()
        {
            redSkullslimeCD = 0;
        }

        private void Update()
        {
            redSkullslimeCD += Time.deltaTime;
            if (redSkullslimeCD > 5)
            {
                SpawnEnemy.Instance.SpawnRedSkullslime(1, transform.position);
                redSkullslimeCD = 0;
            }
        }
    }
}
