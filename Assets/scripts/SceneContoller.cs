using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    // ボタンが押されたときに呼び出す関数
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