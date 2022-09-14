using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyFollowAggro : MonoBehaviour
    {
        [SerializeField] private EnemyFollow _follow;
        [SerializeField] private EnemyBackToIdle _backToIdle;
        [SerializeField] private TriggerObserver _triggerObserver;
        
        private void Start()
        {
            _triggerObserver.OnEntered += OnEntered;
            _triggerObserver.OnExited += OnExited;
        }
        private void OnEntered(Collider2D col)
        {
            _follow.enabled = true;
            _backToIdle.enabled = false;
        }

        private void OnExited(Collider2D other)
        {
            _follow.enabled = false;
            _backToIdle.enabled = true;
        } 
    }
}