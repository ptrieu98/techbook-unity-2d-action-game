using UnityEngine;
using UnityEngine.SceneManagement; // Rất quan trọng: Thêm thư viện này để quản lý Scene

public class MainMenuController : MonoBehaviour
{
    // Hàm này sẽ được gọi bởi nút "START"
    // Đảm bảo tên "MainGame" chính xác 100% với tên file Scene của bạn
    public void StartGame()
    {
        SceneManager.LoadScene("loadScene");
    }

    // Hàm này sẽ được gọi bởi nút "QUIT"
    public void QuitGame()
    {
        // Dòng Debug.Log này để bạn kiểm tra trong Editor,
        // vì Application.Quit() không hoạt động khi chạy trong Editor.
        Debug.Log("Đã nhấn nút Quit!");

        // Thoát ứng dụng (chỉ hoạt động khi bạn build game thành file .exe, .apk...)
        Application.Quit();
    }
}