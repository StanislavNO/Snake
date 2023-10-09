using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class TailController : MonoBehaviour
    {
        [SerializeField] private Transform _head;
        [SerializeField] private Transform _tail;

        private List<Vector3> _positions;
        private List<Transform> _tails;

        private void OnEnable()
        {
            EventBus.FoodPickedUp.AddListener(AddTail);
            EventBus.FoodPickedUp.AddListener(RemoveTail);
        }

        private void OnDisable()
        {
            EventBus.FoodPickedUp.RemoveListener(AddTail);
            EventBus.FoodPickedUp.RemoveListener(RemoveTail);
        }

        private void Start()
        {
            _positions = new List<Vector3>();
            _tails = new List<Transform>();

            _positions.Add(_head.position);
        }

        public void Mov()
        {
            if (_tails != null)
            {
                for (int i = 0; i < _tails.Count; i++)
                {
                    _tails[i].position = _positions[i];
                }

                _positions.Insert(0, _head.position);
                _positions.RemoveAt(_positions.Count - 1);
            }
        }

        private void AddTail(int value)
        {
            if (value > 0)
            {
                var newTail = Instantiate(_tail, _positions[_positions.Count - 1], Quaternion.identity);
                _positions.Add(newTail.position);
                _tails.Add(newTail);
            }
        }

        private void RemoveTail(int value)
        {
            if (_tails.Count > 0 && value < 0)
            {
                Destroy(_tails[_tails.Count - 1].gameObject);

                _tails.RemoveAt(_tails.Count - 1);
                _positions.RemoveAt(_positions.Count - 1);
            }
        }
    }
}