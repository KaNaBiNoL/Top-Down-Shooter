using System;
using UnityEngine;

namespace TDS.Game.Objects.ExplosiveBarrel
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _radius;
        [SerializeField] private BarrelAnimation _animation;
        

        

        public void Explode()
        {
            _animation.PlayExplosion();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (Collider2D col in colliders)
            {
                IHealth health = col.GetComponent<IHealth>();
                if (health != null)
                {
                    health.ApplyDamage(_damage);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}