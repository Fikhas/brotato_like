using System.Collections;
using System.Collections.Generic;
using BrotatoLike.Pooling;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField]
    private ObjectPool potionObject;
    [SerializeField]
    private float dropChance;

    public void DropPotion(Transform potionPos)
    {
        float potionDrop = Random.Range(0f, 100f);

        if (potionDrop <= dropChance)
        {
            Instantiate(potionObject, potionPos.position, Quaternion.identity);
        }
    }
}
