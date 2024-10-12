using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BrotatoLike.Shop
{
    public class ShopSystem : MonoBehaviour
    {
        public static ShopSystem Instance;

        [SerializeField]
        private List<GameObject> menuBoxes;

        private void Awake()
        {
            Instance = this;
            ChangeMenuBox("WeaponsBox");
        }

        public void ChangeMenuBox(string menuName)
        {
            foreach (var menuBox in menuBoxes)
            {
                if (menuBox.name == menuName)
                {
                    menuBox.GetComponent<CanvasGroup>().alpha = 1;
                }
                else
                {
                    menuBox.GetComponent<CanvasGroup>().alpha = 0;
                }
            }
        }
    }
}
