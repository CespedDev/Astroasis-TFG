using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RhythmSystem
{
    public class RhythmChecker : MonoBehaviour
    {
        [SerializeField]
        private DamageDealerType damageDealerType;

        private float damage;

        public RhythmBonusSO rhythmBonus { get; internal set;}

        private void Start()
        {
            // First we save the default damage

            switch (damageDealerType)
            {
                case DamageDealerType.RaycastWeapon:
                    damage = GetComponent<BNG.RaycastWeapon>().Damage;
                    break;
                case DamageDealerType.DamageCollider:
                    damage = GetComponent<BNG.DamageCollider>().Damage;
                    break;
            }
        }

        public void CheckRhythm ()
        {
            // Invoke RhythmCheckEvent(RhythmChecker)
            Debug.Log("Checking Rhythm");

            // Change weapon damage
            switch (damageDealerType)
            {
                case DamageDealerType.RaycastWeapon:
                    GetComponent<BNG.RaycastWeapon>().Damage  = damage * rhythmBonus.Bonus;
                    break;
                case DamageDealerType.DamageCollider:
                    GetComponent<BNG.DamageCollider>().Damage = damage * rhythmBonus.Bonus;
                    break;
            }

            Debug.Log($"Base damage:  {damage}\n" +
                      $"Rhythm bonus: {rhythmBonus.Bonus}");
        }

        enum DamageDealerType
        {
            RaycastWeapon  = 0,
            DamageCollider = 1,
        }
    }
}
