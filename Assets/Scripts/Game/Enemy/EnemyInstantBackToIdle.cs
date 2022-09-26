using System;
using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    class EnemyInstantBackToIdle : EnemyBackToIdle
    {
        [SerializeField] private EnemyIdle _idle;

        public override void Activate()
        {
            base.Activate();
            
            DeActivate();
            _idle.Activate();
        }
    }
}