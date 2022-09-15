using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void PlayAttack()
        {
            _animator.SetTrigger("Attack");
        }

        public void PlayDeath()
        {
            _animator.SetTrigger("Death");
        }
    }
}