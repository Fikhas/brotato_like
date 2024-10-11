using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

namespace BrotatoLike.Character
{
    public class XPSystem : MonoBehaviour
    {
        public static XPSystem Instance;

        [SerializeField]
        private Slider slider;
        [SerializeField]
        private TMP_Text levelText;

        private float currentLevel;
        private float maxXP;
        private float currentXP;

        private void Awake()
        {
            Instance = this;
            InitializeXPSlider();
        }

        private void InitializeXPSlider()
        {
            currentLevel = 1;
            currentXP = 0;
            levelText.text = $"Level {currentLevel}";
            maxXP = currentLevel * 10;
            slider.maxValue = maxXP;
            slider.value = currentXP;
        }

        public void UpdateXP(int xpToAdd)
        {
            currentXP += xpToAdd;
            slider.value = currentXP;

            if (currentXP == maxXP)
            {
                currentLevel += 1;
                levelText.text = $"Level {currentLevel}";
                currentXP = 0;
                maxXP = currentLevel * 10;
                slider.maxValue = maxXP;
                slider.value = currentXP;
            }
        }
    }
}
