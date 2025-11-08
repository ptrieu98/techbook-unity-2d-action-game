using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuController : MonoBehaviour
{
    // Tên của scene game chính để chơi lại
    public string mainGameSceneName = "MainGame"; 

    // Hàm này sẽ được gọi bởi nút "Chơi Lại"
    public void PlayAgain()
    {
        // Đảm bảo Time Scale là 1 (phòng khi game bị pause)
        Time.timeScale = 1f; 
        
        // Tải lại scene MainGame
        SceneManager.LoadScene(mainGameSceneName);
    }

    // Hàm này sẽ được gọi bởi nút "Thoát"
    public void QuitGame()
    {
        // Dòng Debug để kiểm tra trong Editor
        Debug.Log("Đã nhấn nút Thoát!");
        
        // Thoát ứng dụng
        Application.Quit();
    }
}