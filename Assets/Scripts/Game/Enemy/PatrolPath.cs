using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class PatrolPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;
        private int _currentIndex;
        public bool IsReached(Vector3 currentPosition, float distanceToPoint)
        {
            throw new System.NotImplementedException();
        }

        public void SetNextPoint()
        {
            _currentIndex++;
            if (_currentIndex >= _points.Count)
            {
                _currentIndex = 0;
            }
        }

        public Transform CurrentPoint()
        {
            return _points[_currentIndex];
        }
    }
}