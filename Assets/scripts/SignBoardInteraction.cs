using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignboardConversation : MonoBehaviour
{
    [Header("UI パネル")]
    public GameObject promptUI;       // プロンプトを表示するパネル
    public GameObject infoWindowUI;   // 会話ウィンドウ

    [Header("プロンプト用テキスト")]
    public TMP_Text promptText;       // promptUI 内の TextMeshProUGUI コンポーネント

    [Header("プロンプト文言")]
    public string initialPrompt = "F:話を聞く";
    public string continuePrompt = "F:会話を続ける";
    public string endPrompt = "F:会話を終える";

    [Header("インタラクト設定")]
    public KeyCode interactKey = KeyCode.F;

    [Header("看板ごとの会話テキスト")]
    [TextArea(2, 5)]
    public string[] messages;         // Inspector で順に設定
    public TMP_Text infoText;         // InfoWindowUI 内の TextMeshProUGUI

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
            // まだ会話ウィンドウが閉じている → 開いて最初のメッセージ
            if (!infoWindowUI.activeSelf)
            {
                currentMessageIndex = 0;
                ShowMessage(0);
                infoWindowUI.SetActive(true);

                // 次があれば「続ける」、なければ「終える」
                promptText.text = (messages.Length > 1)
                                  ? continuePrompt
                                  : endPrompt;
                promptUI.SetActive(true);
            }
            else
            {
                // 会話ウィンドウが開いている → 次のメッセージ or 終了
                currentMessageIndex++;

                if (currentMessageIndex < messages.Length)
                {
                    ShowMessage(currentMessageIndex);

                    // 最後のメッセージなら endPrompt、それ以外は continuePrompt
                    promptText.text = (currentMessageIndex == messages.Length - 1)
                                      ? endPrompt
                                      : continuePrompt;
                    promptUI.SetActive(true);
                }
                else
                {
                    // 会話終了
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
            // ウィンドウ閉じてるときだけ初期プロンプトを出す
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
