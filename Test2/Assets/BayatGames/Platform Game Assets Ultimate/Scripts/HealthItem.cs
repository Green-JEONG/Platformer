using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames
{
    public class HealthItem : MonoBehaviour
    {
        public float healAmount = 20f; // ü�� ȸ����

        private void OnTriggerEnter2D(Collider2D other)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Heal(healAmount);
                Destroy(gameObject); // �������� �ı�
            }
        }
    }
}
