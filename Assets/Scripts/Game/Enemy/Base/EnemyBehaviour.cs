using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        public bool IsActive { get; private set; }

        private void Update()
        {
            if (IsActive)
            {
                OnUpdate();
            }
        }

        public virtual void Activate()
        {
            IsActive = true;
        }

        public virtual void DeActivate()
        {
            IsActive = false;
        }
        
        protected virtual void OnUpdate(){}
    }
}