using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.SOScripts
{
    public class BulletSO : MonoBehaviour
    {
        public List<BulletList> bulletLists = new List<BulletList>();
    }

    [Serializable]
    public class BulletList
    {
        public string bulletName;
        public Sprite bulletSprite;
    }
}
