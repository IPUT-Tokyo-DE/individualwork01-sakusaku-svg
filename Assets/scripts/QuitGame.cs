using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        // エディタでは終了せずに、ビルド後は動く
        Application.Quit();

        // デバッグ用（エディタ上で確認したいとき）
        Debug.Log("ゲーム終了処理が呼ばれました！");
    }
}