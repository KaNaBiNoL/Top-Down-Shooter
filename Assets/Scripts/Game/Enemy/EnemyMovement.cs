using UnityEngine;

namespace TDS.Game.Enemy
{
    public abstract class EnemyMovement : MonoBehaviour
    {
        public abstract void SetTarger(Transform target);
    }
}