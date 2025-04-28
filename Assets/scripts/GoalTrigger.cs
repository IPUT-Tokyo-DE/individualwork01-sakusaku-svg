using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    public string stageSelectSceneName = "StageSelectScene"; // ← シーン名

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ゴールに到達！");
            SceneManager.LoadScene(stageSelectSceneName);
        }
    }
}
