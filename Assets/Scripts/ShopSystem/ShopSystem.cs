using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Character;
using BrotatoLike.Coin;
using BrotatoLike.Enemy;
using BrotatoLike.Potion;
using BrotatoLike.Spawn;
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
            WeaponsBoxScript.Instance.InitializeWeaponShop();
            CoinScript.Instance.AddCoinToPlayer();
            GameShopConnector.Instance.InitializeShopPanel();
            WeaponsBoxScript.Instance.UpdateWeaponAmount();
            WeaponSystem.Instance.WeaponOff();
        }

        public void ContinueWave()
        {
            GameManager.Instance.gameState = GameState.Gameplay;
            shopPanel.SetActive(false);
            WaveManager.Instance.StartWave();
            CoinScript.Instance.ResetCoin();
            WeaponsBoxScript.Instance.AssignWeapon();
            CharController.Instance.gameObject.transform.position = Vector2.zero;
            CharController.Instance.UpdateHP();
            SpawnEnemy.Instance.DestroyAllEnemy();
            PotionScript.Instance.DestroyAllPotion();
            CoinScript.Instance.DestroyAllCoin();
            CameraMovement.Instance.gameObject.transform.position = new Vector3(0, 0, -10);
            XPSystem.Instance.ResetXP();
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
