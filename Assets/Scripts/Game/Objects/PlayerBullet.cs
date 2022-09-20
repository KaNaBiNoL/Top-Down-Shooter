using System;
using System.Collections;
using TDS.Controll;
using TDS.Game.Enemy;
using UnityEngine;

namespace TDS.Game.Objects
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerBullet : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifeTime = 5f;
        [SerializeField] private int _damage = 30;
        

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _rb.velocity = transform.up * _speed;
            StartCoroutine(LifeTimeTimer());
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(Tags.Enemy))
            {
                col.GetComponent<EnemyHealth>().ApplyDamage(_damage);
                Destroy(gameObject);
            }
            else if (col.CompareTag(Tags.Barrel))
            {
                Destroy(gameObject);
            }
        }

        private IEnumerator LifeTimeTimer()
        {
            yield return new WaitForSeconds(_lifeTime);
            
            Destroy(gameObject);
        }
    }
}