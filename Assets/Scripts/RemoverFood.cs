using UnityEngine;

namespace Assets.Scripts
{
    public class RemoverFood : Food
    {
        [SerializeField][Range(-3, -1)] private int _price;

        protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Head>(out Head player))
            {
                EventBus.CheriPickedUp(_price);
                Destroy(gameObject);
            }
        }
    }
}