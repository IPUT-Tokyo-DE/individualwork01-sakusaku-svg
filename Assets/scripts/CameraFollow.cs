using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // キャラクター（追いかける対象）
    public float smoothSpeed = 0.125f; // カメラの追従の滑らかさ
    public Vector3 offset;             // カメラのオフセット位置

    public float minX, maxX;           // カメラの左右限界（ステージの端）

    void LateUpdate()
    {
        if (target != null)
        {
            float desiredX = target.position.x + offset.x;

            // X位置を制限する（カメラが端を越えないように）
            float clampedX = Mathf.Clamp(desiredX, minX, maxX);
            Vector3 desiredPosition = new Vector3(clampedX, target.position.y + offset.y, offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
