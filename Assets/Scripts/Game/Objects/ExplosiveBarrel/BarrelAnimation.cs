using UnityEngine;

namespace TDS.Game.Objects.ExplosiveBarrel
{
    public class BarrelAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _barrel;
        

        public void PlayExplosion()
        {
            _animator.SetTrigger("Explosion");
        }

        public void Destruction()
        {
            Destroy(_barrel);
        }
    }
}