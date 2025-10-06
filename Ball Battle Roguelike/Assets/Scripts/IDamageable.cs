using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damage
{
    public interface IDamageable
    {
        public void TakeDamage(double damage, DamageType damageType);
    }

    public enum DamageType
    {
        None = 0,
        Physical = 1,
        Magic = 2,
    }
}
