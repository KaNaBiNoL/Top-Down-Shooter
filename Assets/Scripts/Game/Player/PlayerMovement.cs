using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;
        
        [SerializeField] private float _speed = 12f;

        private Rigidbody2D _rb;
        private Transform _cachedTransform;
        private Camera _mainCamera;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _cachedTransform = transform;
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            Move();
            Rotate();
        }
        private void OnDisable()
        {
            _rb.velocity = Vector2.zero;
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontal, vertical);
            Vector3 moveDelta = direction * (_speed);
            _rb.velocity = moveDelta;

            _playerAnimation.SetSpeed(direction.magnitude);
        }

        private void Rotate()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldPoint = _mainCamera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0f;

            Vector3 direction = worldPoint - _cachedTransform.position;
            _cachedTransform.up += direction;
        }
    }
}