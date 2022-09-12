using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAnimation _playerAnimation;

        public bool IsDead { get; private set; }

        private void Start()
        {
            _playerHealth.OnChanged += OnHpChanged;
        }

        private void OnHpChanged(int health)
        {
            if (IsDead || health > 0)
            {
                return;
            }

            IsDead = true;
            _playerAttack.enabled = false;
            _playerMovement.enabled = false;
            _playerAnimation.PlayDeath();
        }
    }
}