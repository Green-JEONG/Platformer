using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames
{
    public class HealthItem : MonoBehaviour
    {
        public float healAmount = 20f; // 체력 회복량

        private void OnTriggerEnter2D(Collider2D other)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Heal(healAmount);
                Destroy(gameObject); // 아이템을 파괴
            }
        }
    }
}
