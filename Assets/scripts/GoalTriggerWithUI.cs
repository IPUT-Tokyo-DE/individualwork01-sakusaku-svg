using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTriggerWithUI : MonoBehaviour
{
    public GameObject goalUIPanel;
    public string stageSelectSceneName = "StageSelectScene";

    private bool hasShownUI = false; // 一度だけ表示するように制御

    void Start()
    {
        if (goalUIPanel != null)
        {
            goalUIPanel.SetActive(false); // 最初は非表示
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasShownUI)
        {
            hasShownUI = true; // UIが表示されたことを記録
            Time.timeScale = 0f; // ゲームを一時停止
            goalUIPanel.SetActive(true); // UI を表示
        }
    }

    public void OnYesButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(stageSelectSceneName); // ステージセレクトへ
    }

    public void OnNoButton()
    {
        Time.timeScale = 1f;
        goalUIPanel.SetActive(false);
        hasShownUI = false; // 再度触れた時にUIを再表示できるようにする
    }
}
