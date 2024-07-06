// Coin.cs
using UnityEngine;

namespace BayatGames
{
    public class Coin : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // 플레이어가 코인에 닿으면 코인을 제거
                Destroy(gameObject);
                // 추가적으로 코인 획득 효과를 처리할 수 있습니다. 예: 점수 증가 등
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player.CollectCoin();
                }
            }
        }
    }
}