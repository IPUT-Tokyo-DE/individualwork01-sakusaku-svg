using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        // �G�f�B�^�ł͏I�������ɁA�r���h��͓���
        Application.Quit();

        // �f�o�b�O�p�i�G�f�B�^��Ŋm�F�������Ƃ��j
        Debug.Log("�Q�[���I���������Ă΂�܂����I");
    }
}