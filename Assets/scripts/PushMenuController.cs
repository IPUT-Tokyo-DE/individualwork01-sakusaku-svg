using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenuController : MonoBehaviour
{
    [Header("UI�ݒ�")]
    public GameObject pauseMenuPanel;       // PauseMenuPanel���A�^�b�`
    public TMP_Text stageNameText;             // StageNameText���A�^�b�`

    private bool isPaused = false;

    void Update()
    {
        // Esc�L�[�Ńg�O��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    // �|�[�Y
    private void PauseGame()
    {
        isPaused = true;
        // �V�[������\��
        stageNameText.text = "�X�e�[�W: " + SceneManager.GetActiveScene().name;
        // ���j���[�\�������Ԓ�~
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // �ĊJ
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    // �^�C�g���ɖ߂�
    public void ExitToTitle()
    {
        // ���ԃX�P�[����߂��Ă���V�[���J��
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageSelect");  // �V�[�����͓K�X�ύX
    }
}
