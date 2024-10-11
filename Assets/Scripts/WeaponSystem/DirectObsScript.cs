using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.Weapon
{
    public class DirectObsScript : MonoBehaviour
    {
        public static DirectObsScript Instance;
        public Vector3 direction;
        public Vector3 mousePosition;
        public float currentRot;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            currentRot = angle;

            // transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
}
