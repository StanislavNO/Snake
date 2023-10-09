using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class AddFood : Food
    {
        [SerializeField][Range(1, 3)] private int _price;

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