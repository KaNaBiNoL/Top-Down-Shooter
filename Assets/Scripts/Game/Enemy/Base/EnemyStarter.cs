using System;
using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyStarter : MonoBehaviour
    {
        [SerializeField] private EnemyIdle _idle;

        private void Start()
        {
            _idle.Activate();
        }
    }
}