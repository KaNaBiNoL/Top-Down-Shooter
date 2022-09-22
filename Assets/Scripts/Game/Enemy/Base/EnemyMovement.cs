using UnityEngine;

namespace TDS.Game.Enemy.Base
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        public abstract void SetTarget(Transform target);
    }
}