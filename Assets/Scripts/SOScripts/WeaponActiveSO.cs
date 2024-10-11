using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoLike.SOScripts
{
    [CreateAssetMenu(fileName = "WeaponActiveSO", menuName = "WeaponSO/WeaponActiveSO", order = 1)]
    public class WeaponActiveSO : ScriptableObject
    {
        public List<string> weaponNames = new List<string>();
    }
}
