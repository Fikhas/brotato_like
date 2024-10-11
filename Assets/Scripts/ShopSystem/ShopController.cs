using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.Shop
{
    [RequireComponent(typeof(ShopModel), typeof(ShopView))]
    public class ShopController : MonoBehaviour
    {
        public static ShopController Instance;
        [SerializeField]
        private GameObject shopPanel;

        private void Awake()
        {
            Instance = this;
        }

        public void ShopAppear()
        {
            shopPanel.SetActive(true);
        }

        public void ShopDisapper()
        {
            shopPanel.SetActive(false);
        }
    }
}
