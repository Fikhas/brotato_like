using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Wave;
using BrotatoLike.Weapon;
using TMPro;
using UnityEngine;

namespace BrotatoLike.Shop
{
    public class ShopSystem : MonoBehaviour
    {
        public static ShopSystem Instance;

        [SerializeField]
        private GameObject shopPanel;
        [SerializeField]
        private List<GameObject> menuBoxes;

        private void Awake()
        {
            Instance = this;
            shopPanel.SetActive(false);
            ChangeMenuBox("WeaponsBox");
        }

        public void ShopActive()
        {
            GameManager.Instance.gameState = GameState.Shop;
            if (WaveManager.Instance.currentWave < WaveManager.Instance.waveAmount)
            {
                WaveManager.Instance.currentWave += 1;
            }
            shopPanel.SetActive(true);
            GameShopConnector.Instance.InitializeShopPanel();
            WeaponsBoxScript.Instance.UpdateWeaponAmount();
        }

        public void ContinueWave()
        {
            shopPanel.SetActive(false);
            Debug.Log("Next Wave");
            WaveManager.Instance.StartWave();
            GameManager.Instance.gameState = GameState.Gameplay;
            WeaponsBoxScript.Instance.AssignWeapon();
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
