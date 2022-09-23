using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyAnimationMediator : MonoBehaviour
    {
        [SerializeField] private EnemyMeleeAttack _attack;

        public void PerformDamage()
        {
            _attack.PerformDamage();
        }
    }
}