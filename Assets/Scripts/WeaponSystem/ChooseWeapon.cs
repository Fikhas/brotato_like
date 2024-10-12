using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.Weapon
{
    public class ChooseWeapon : MonoBehaviour
    {
        public static ChooseWeapon Instance;

        [SerializeField]
        private GameObject chooseWeaponPanel;

        private void Awake()
        {
            Instance = this;
            chooseWeaponPanel.SetActive(false);
        }

        public void ChooseWeaponOn()
        {
            GameManager.Instance.gameState = GameState.ChooseWeapon;
            chooseWeaponPanel.SetActive(true);
        }

        public void ChooseWeaponOff()
        {
            GameManager.Instance.gameState = GameState.Gameplay;
            chooseWeaponPanel.SetActive(false);
        }

        public void ChooseFireStaff()
        {
            WeaponSystem.Instance.SetWeapon("FireStaff");
            ChooseWeaponOff();
        }

        public void ChooseIceStaff()
        {
            WeaponSystem.Instance.SetWeapon("IceStaff");
            ChooseWeaponOff();
        }

        public void ChooseLightningStaff()
        {
            WeaponSystem.Instance.SetWeapon("LightningStaff");
            ChooseWeaponOff();
        }
    }
}
