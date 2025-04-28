using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTriggerWithUI : MonoBehaviour
{
    public GameObject goalUIPanel;
    public string stageSelectSceneName = "StageSelectScene";

    private bool hasShownUI = false; // ��x�����\������悤�ɐ���

    void Start()
    {
        if (goalUIPanel != null)
        {
            goalUIPanel.SetActive(false); // �ŏ��͔�\��
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasShownUI)
        {
            hasShownUI = true; // UI���\�����ꂽ���Ƃ��L�^
            Time.timeScale = 0f; // �Q�[�����ꎞ��~
            goalUIPanel.SetActive(true); // UI ��\��
        }
    }

    public void OnYesButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(stageSelectSceneName); // �X�e�[�W�Z���N�g��
    }

    public void OnNoButton()
    {
        Time.timeScale = 1f;
        goalUIPanel.SetActive(false);
        hasShownUI = false; // �ēx�G�ꂽ����UI���ĕ\���ł���悤�ɂ���
    }
}
