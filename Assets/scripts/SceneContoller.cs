using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    // ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Æ‚«‚ÉŒÄ‚Ño‚·ŠÖ”
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