using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignboardConversation : MonoBehaviour
{
    [Header("UI �p�l��")]
    public GameObject promptUI;       // �v�����v�g��\������p�l��
    public GameObject infoWindowUI;   // ��b�E�B���h�E

    [Header("�v�����v�g�p�e�L�X�g")]
    public TMP_Text promptText;       // promptUI ���� TextMeshProUGUI �R���|�[�l���g

    [Header("�v�����v�g����")]
    public string initialPrompt = "F:�b�𕷂�";
    public string continuePrompt = "F:��b�𑱂���";
    public string endPrompt = "F:��b���I����";

    [Header("�C���^���N�g�ݒ�")]
    public KeyCode interactKey = KeyCode.F;

    [Header("�Ŕ��Ƃ̉�b�e�L�X�g")]
    [TextArea(2, 5)]
    public string[] messages;         // Inspector �ŏ��ɐݒ�
    public TMP_Text infoText;         // InfoWindowUI ���� TextMeshProUGUI

    private bool isPlayerNearby = false;
    private int currentMessageIndex = 0;

    void Start()
    {
        promptUI.SetActive(false);
        infoWindowUI.SetActive(false);
    }

    void Update()
    {
        if (!isPlayerNearby) return;

        if (Input.GetKeyDown(interactKey))
        {
            // �܂���b�E�B���h�E�����Ă��� �� �J���čŏ��̃��b�Z�[�W
            if (!infoWindowUI.activeSelf)
            {
                currentMessageIndex = 0;
                ShowMessage(0);
                infoWindowUI.SetActive(true);

                // ��������΁u������v�A�Ȃ���΁u�I����v
                promptText.text = (messages.Length > 1)
                                  ? continuePrompt
                                  : endPrompt;
                promptUI.SetActive(true);
            }
            else
            {
                // ��b�E�B���h�E���J���Ă��� �� ���̃��b�Z�[�W or �I��
                currentMessageIndex++;

                if (currentMessageIndex < messages.Length)
                {
                    ShowMessage(currentMessageIndex);

                    // �Ō�̃��b�Z�[�W�Ȃ� endPrompt�A����ȊO�� continuePrompt
                    promptText.text = (currentMessageIndex == messages.Length - 1)
                                      ? endPrompt
                                      : continuePrompt;
                    promptUI.SetActive(true);
                }
                else
                {
                    // ��b�I��
                    infoWindowUI.SetActive(false);
                    promptUI.SetActive(false);
                }
            }
        }
    }

    private void ShowMessage(int idx)
    {
        infoText.text = messages[idx];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            // �E�B���h�E���Ă�Ƃ����������v�����v�g���o��
            if (!infoWindowUI.activeSelf)
            {
                promptText.text = initialPrompt;
                promptUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            infoWindowUI.SetActive(false);
            promptUI.SetActive(false);
        }
    }
}
