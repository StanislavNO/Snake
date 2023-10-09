using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Head : Snake
    {
        [SerializeField] private float _stepTime;
        [SerializeField] private UnityEvent _movement;

        public bool IsEat { get; private set; }

        private float _timer;
        private Vector3 _duration;

        private void Start()
        {
            _duration = Vector3.up;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                IsEat = true;
            }
            else
            {
                IsEat = false;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _duration = Vector3.up;
                transform.rotation = Quaternion.Euler(Vector3.zero);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _duration = Vector3.left;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _duration = Vector3.right;
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _duration = Vector3.down;
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            _timer += Time.deltaTime;

            if (_timer >= _stepTime)
            {
                transform.position += _duration;
                _movement.Invoke();

                _timer = 0;
            }
        }
    }
}