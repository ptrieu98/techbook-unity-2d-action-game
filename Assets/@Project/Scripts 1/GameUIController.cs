using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    // ---- Singleton Pattern ----
    public static GameUIController instance; 
    // ---------------------------

    [Header("UI Elements")]
    public TextMeshProUGUI appleText;

    private int appleCount = 0;

    void Awake()
    {
        // Thiết lập Singleton
        if (instance == null)
        {
            instance = this;
            
            // THÊM DÒNG NÀY:
            // Bảo Unity không hủy GameObject này khi tải scene mới.
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // Nếu đã có 1 instance tồn tại, tự hủy
            // (ví dụ: khi chơi lại từ Victory -> MainGame)
            Destroy(gameObject);
        }
    }

    void Start()
    {
        appleText.text = "Táo: " + appleCount;
    }

    public void AddApple()
    {
        appleCount++;
        appleText.text = "Táo: " + appleCount;
    }
}