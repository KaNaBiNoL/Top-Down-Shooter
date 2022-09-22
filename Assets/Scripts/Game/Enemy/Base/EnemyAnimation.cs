using UnityEngine;

namespace TDS.Game.Enemy.Base
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

        public void SetSpeed(float speed)
        {
            _animator.SetFloat("Speed", speed);
        }
    }
}