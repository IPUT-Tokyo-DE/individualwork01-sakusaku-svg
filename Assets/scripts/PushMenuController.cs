using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    [Header("UI設定")]
    public GameObject pauseMenuPanel;       // PauseMenuPanelをアタッチ
    public TMP_Text stageNameText;             // StageNameTextをアタッチ

    private bool isPaused = false;

    void Update()
    {
        // Escキーでトグル
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    // ポーズ
    private void PauseGame()
    {
        isPaused = true;
        // シーン名を表示
        stageNameText.text = "ステージ: " + SceneManager.GetActiveScene().name;
        // メニュー表示＆時間停止
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // 再開
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // タイトルに戻る
    public void ExitToTitle()
    {
        // 時間スケールを戻してからシーン遷移
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageSelect");  // シーン名は適宜変更
    }
}
