﻿using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttackAggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyMovement _enemyMovement;

        private bool _isInRange;

        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }

        private void Update()
        {
            if (_isInRange)
            {
                _enemyAttack.Attack();
            }
        }

        private void OnEntered(Collider2D col)
        {
            _isInRange = true;
            _enemyMovement.enabled = false;
        }

        private void OnExited(Collider2D col)
        {
            _isInRange = false;
            _enemyMovement.enabled = true;
        }
    }
}