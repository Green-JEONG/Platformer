using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Player player = collision.GetComponent<Player>();
                if (player != null)
                {
                    player.Death();
                }
            }
        }
    }
}