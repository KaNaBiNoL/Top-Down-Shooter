using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public class EnemyFollowAggro : MonoBehaviour
    {
        [SerializeField] private EnemyFollow _follow;
        [SerializeField] private EnemyBackToIdle _backToIdle;
        [SerializeField] private EnemyIdle _idle;
        
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }
        private void OnEntered(Collider2D col)
        {
            if (_idle.IsActive)
            {
                _idle.DeActivate();
            }
            else
            {
                _backToIdle.DeActivate();
            }
            
            _follow.Activate();
        }

        private void OnExited(Collider2D other)
        {
            _follow.DeActivate();
            _backToIdle.Activate();
        } 
    }
}