using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingController : MonoBehaviour
{
    [Header("UI Elements")]
    public Slider loadingSlider;
    public TextMeshProUGUI progressText;

    [Header("Loading Settings")]
    public string sceneToLoad = "MainGame";
    
    // THÊM BIẾN NÀY:
    // Tổng thời gian (giây) để thanh loading chạy từ 0-100%
    public float loadDuration = 2.0f; // <-- Đặt là 2 giây như bạn muốn

    void Start()
    {
        // Thêm dòng này để đảm bảo game không bị pause
        Time.timeScale = 1f; 
        
        // Đảm bảo thanh loading bắt đầu ở 0
        loadingSlider.value = 0;
        progressText.text = "0%";
        
        StartCoroutine(LoadSceneAsync());
    }

    // SỬA LẠI TOÀN BỘ HÀM NÀY
    IEnumerator LoadSceneAsync()
    {
        // Bắt đầu tải scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        
        // 1. Ngăn scene tự động kích hoạt ngay khi tải xong
        // (Nó sẽ tải đến 90% rồi dừng lại chờ)
        asyncLoad.allowSceneActivation = false;

        float elapsedTime = 0f;

        // 2. Vòng lặp này chạy thanh loading dựa trên thời gian,
        // không quan tâm đến tiến độ tải thật.
        while (elapsedTime < loadDuration)
        {
            // Tăng thời gian đã trôi qua
            elapsedTime += Time.deltaTime;

            // Tính toán % dựa trên thời gian (0-2 giây)
            float progress = Mathf.Clamp01(elapsedTime / loadDuration);

            // Cập nhật UI (Slider và Text)
            loadingSlider.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            yield return null; // Chờ 1 frame
        }

        // ----- HẾT 2 GIÂY -----

        // 3. Đảm bảo UI chắc chắn hiển thị 100%
        loadingSlider.value = 1f;
        progressText.text = "100%";

        // 4. Chờ cho đến khi scene THỰC SỰ tải xong
        // (Phòng trường hợp máy chậm, tải lâu hơn 2 giây)
        while (asyncLoad.progress < 0.9f)
        {
            yield return null;
        }

        // 5. Đã tải xong VÀ đã hết 2 giây, cho phép kích hoạt scene
        asyncLoad.allowSceneActivation = true;
    }
}