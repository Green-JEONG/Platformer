using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames;

public class speedupItem : MonoBehaviour
{
    public float speedMultiplier = 2f; // 속도 배율
    public float duration = 5f; // 지속 시간

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.BoostSpeed(speedMultiplier, duration);
            Destroy(gameObject); // 아이템을 파괴
        }
    }
}
