using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.SOScripts
{
    [CreateAssetMenu(fileName = "EnemiesSO_", menuName = "EnemiesSO/EnemyList", order = 0)]
    public class EnemiesSO : ScriptableObject
    {
        public List<EnemyList> enemyLists = new List<EnemyList>();
    }
}

[Serializable]
public class EnemyList
{
    public string enemyName;
    public float hp;
    public float damage;
    public float speed;
    public float coin;
    public Vector3 scale;
    public Sprite enemySprite;
}
