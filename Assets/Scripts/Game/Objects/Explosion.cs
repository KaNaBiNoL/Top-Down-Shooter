using UnityEngine;

namespace TDS.Game.Objects
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _radius;

        private void Explode()
        {
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
    }
}