using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    // �{�^���������ꂽ�Ƃ��ɌĂяo���֐�
    public void OnStageSelectButtonPressed()
    {
        SceneManager.LoadScene("StageSelect");

    }
    public void OnStartMenuButtonPressed()
    {
        SceneManager.LoadScene("StartMenu");

    }
    public void OnStage1ButtonPressed()
    {
        SceneManager.LoadScene("Stage1");

    }
    public void OnStage2ButtonPressed()
    {
        SceneManager.LoadScene("Stage2");

    }
}