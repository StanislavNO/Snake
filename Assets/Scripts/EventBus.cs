using UnityEngine.Events;

namespace Assets.Scripts
{
    public static class EventBus
    {
        public static readonly UnityEvent<int> FoodPickedUp = new UnityEvent<int>();

        public static void CheriPickedUp(int value)
        {
            FoodPickedUp.Invoke(value);
        }
    }
}