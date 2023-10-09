using UnityEngine;

namespace Assets.Scripts
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioAddFood;
        [SerializeField] private AudioSource _soundRemoveFood;

        private void OnEnable()
        {
            EventBus.FoodPickedUp.AddListener(Play);
        }

        private void Play(int value)
        { 
            if (value > 0)
                _audioAddFood.Play();
            else
                _soundRemoveFood.Play();
        }
    }
}