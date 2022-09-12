﻿using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 4f;
        
        private Rigidbody2D _rb;
        private Transform _target;
        private Transform _cachedTransform;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
        }

        private void FixedUpdate()
        {
            if (!IsTargetValid())
            {
                return;
            }

            MoveToTarget();
        }

        public void SetTarger(Transform target)
        {
            _target = target;
        }

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            _rb.velocity = direction * _speed;
        }

        private bool IsTargetValid()
        {
            return _target != null;
        }
    }
}