using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    public string stageSelectSceneName = "StageSelectScene"; // �� �V�[����

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�S�[���ɓ��B�I");
            SceneManager.LoadScene(stageSelectSceneName);
        }
    }
}
