using TDS.Game.Enemy.Base;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyPatrol : EnemyIdle
    {
        [SerializeField] private PatrolPath _path;
        [SerializeField] private EnemyMovement _movement;
        [SerializeField] private float _distanceToPoint = 1f;

        public override void Activate()
        {
            base.Activate();
            SetCurrentPointAsTarget();
        }

        public override void DeActivate()
        {
            base.DeActivate();
            _movement.SetTarget(null);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            CheckDistance();
        }

        private void SetTarget(Transform target)
        {
            _movement.SetTarget(target);
        }
        

        private void CheckDistance()
        {
            if (_path.IsReached(transform.position, _distanceToPoint))
            {
                _path.SetNextPoint();
                SetCurrentPointAsTarget();
            }
        }

        private void SetCurrentPointAsTarget()
        {
            SetTarget(_path.CurrentPoint());
        }
    }
}