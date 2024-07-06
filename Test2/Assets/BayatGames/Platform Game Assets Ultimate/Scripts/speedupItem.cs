using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames;

public class speedupItem : MonoBehaviour
{
    public float speedMultiplier = 2f; // �ӵ� ����
    public float duration = 5f; // ���� �ð�

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.BoostSpeed(speedMultiplier, duration);
            Destroy(gameObject); // �������� �ı�
        }
    }
}
