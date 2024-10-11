using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.SOScripts
{
    [CreateAssetMenu(fileName = "ItemSO", menuName = "ItemSO/Item", order = 0)]
    public class ItemSO : ScriptableObject
    {
        public List<ItemList> itemLists = new List<ItemList>();
    }

    [Serializable]
    public class ItemList
    {
        public string itemName;
        public Sprite itemSprite;
        public int itemPrice;
        public string itemDescription;
        public List<ItemEffect> itemEffects = new List<ItemEffect>();
    }

    [Serializable]
    public class ItemEffect
    {
        public string effectFor;
        public int effectAmount;
    }
}
