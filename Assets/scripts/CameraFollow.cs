using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;           // �L�����N�^�[�i�ǂ�������Ώہj
    public float smoothSpeed = 0.125f; // �J�����̒Ǐ]�̊��炩��
    public Vector3 offset;             // �J�����̃I�t�Z�b�g�ʒu

    public float minX, maxX;           // �J�����̍��E���E�i�X�e�[�W�̒[�j

    void LateUpdate()
    {
        if (target != null)
        {
            float desiredX = target.position.x + offset.x;

            // X�ʒu�𐧌�����i�J�������[���z���Ȃ��悤�Ɂj
            float clampedX = Mathf.Clamp(desiredX, minX, maxX);
            Vector3 desiredPosition = new Vector3(clampedX, target.position.y + offset.y, offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
