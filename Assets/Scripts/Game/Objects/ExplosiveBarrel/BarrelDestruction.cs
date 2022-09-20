using System;
using TDS.Controll;
using UnityEngine;

namespace TDS.Game.Objects.ExplosiveBarrel
{
    public class BarrelDestruction : MonoBehaviour
    {
        [SerializeField] private Explosion _explosion;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.PlayerBullet))
            {
                _explosion.Explode();
            }
        }
    }
}