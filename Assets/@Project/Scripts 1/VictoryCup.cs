using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCup : MonoBehaviour
{
    // Tên của scene chiến thắng
    public string victorySceneName = "Victory";

    // Hàm này sẽ tự động được gọi khi có thứ gì đó đi vào trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem vật thể đi vào có tag "Player" không
        if (other.CompareTag("Player"))
        {
            // Nếu đúng là Player, tải scene Victory
            SceneManager.LoadScene(victorySceneName);
        }
    }
}