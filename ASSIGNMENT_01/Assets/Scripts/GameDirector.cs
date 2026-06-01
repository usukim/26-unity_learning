using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [Header("UI 설정")]
    [SerializeField] private Image[] heartImages;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;

    [Header("기타 설정")]
    [SerializeField] private float fallCooldown = 1.5f;

    public static GameDirector instance;
    public static bool isGameOver = false;

    private int _lives = 3;
    private float _lastFallenTime = 0;

    public void ItemFallOut()
    {
        if (Time.time - _lastFallenTime < fallCooldown)
        {
            Debug.Log("fallout 쿨타임");
            return;
        }

        Debug.Log("떨어짐");
        _lives -= 1;

        // 남은 목숨을 인덱스로 하여 스프라이트 변경
        if (_lives >= 0 && _lives < heartImages.Length)
        {
            heartImages[_lives].sprite = emptyHeart;
        }

        if (_lives < 1) GameOver();

        _lastFallenTime = Time.time;
    }

    public void GameOver()
    {
        Debug.Log("게임 오버");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // 시간 정지
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // 시간 복구

        // 씬 자기자신 다시 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore()
    {
        // 점수 계산
        int propCount = GameObject.FindGameObjectsWithTag("Prop").Length;
        int score = (int)((propCount + CameraController.HighestY) * 100 * (1 + propCount * 0.01f));
        scoreText.text = score.ToString();
    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
