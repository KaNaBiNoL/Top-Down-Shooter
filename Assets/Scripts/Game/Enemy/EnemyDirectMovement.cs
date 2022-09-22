﻿using System;
using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyDirectMovement : EnemyMovement
    {
        [SerializeField] private float _speed = 4f;
        [SerializeField] private EnemyAnimation _animation;

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
            RotateToTarget();
        }

        private void OnDisable()
        {
            SetVelocity(Vector2.zero);
        }

        private void RotateToTarget()
        {
            Vector3 direction = _target.position - _cachedTransform.position;
            _cachedTransform.up += direction;
        }

        public override void SetTarget(Transform target)
        {
            _target = target;
            if (_target == null)
            {
                SetVelocity(Vector2.zero);
            }
        }

        private void MoveToTarget()
        {
            Vector3 direction = (_target.position - _cachedTransform.position).normalized;
            Vector3 velocity = (direction * _speed);
            SetVelocity(velocity);
        }

        private bool IsTargetValid()
        {
            return _target != null;
        }

        private void SetVelocity(Vector2 velocity)
        {
            _rb.velocity = velocity;
            _animation.SetSpeed(velocity.magnitude);
        }
    }
}