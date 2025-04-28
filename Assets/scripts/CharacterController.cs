using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{
    [Header("��{�X�e�[�^�X")]
    public float speed = 5f;
    public float jumpForce = 7f;

    // �p���[�A�b�v��Ԃ̔{���E����
    [Header("�p���[�A�b�v�ݒ�")]
    public float powerUpSpeedMultiplier = 2f;
    public float powerUpJumpMultiplier = 1.5f;
    public float powerUpDuration = 5f;

    private float defaultSpeed;
    private float defaultJumpForce;

    private bool facingRight = false;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Coroutine powerUpCoroutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // ���̃X�e�[�^�X��ۑ����Ă���
        defaultSpeed = speed;
        defaultJumpForce = jumpForce;
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveX * speed * Time.deltaTime);

        if (moveX > 0 && !facingRight) Flip();
        else if (moveX < 0 && facingRight) Flip();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) isGrounded = false;
    }

    // �p���[�A�b�v�A�C�e�����E�����Ƃ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            // �A�C�e���̃p�����[�^������Ă���ꍇ�� PowerUpItem �X�N���v�g��
            // var item = other.GetComponent<PowerUpItem>();
            // StartPowerUp(item.speedMultiplier, item.jumpMultiplier, item.duration);

            // ��{�l���g���Ȃ炱�ꂾ����OK
            StartPowerUp(powerUpSpeedMultiplier, powerUpJumpMultiplier, powerUpDuration);

            // �A�C�e��������
            Destroy(other.gameObject);
        }
    }

    public void StartPowerUp(float speedMul, float jumpMul, float duration)
    {
        // ���Ƀp���[�A�b�v���Ȃ��x���Z�b�g
        if (powerUpCoroutine != null) StopCoroutine(powerUpCoroutine);
        powerUpCoroutine = StartCoroutine(PowerUpRoutine(speedMul, jumpMul, duration));
    }

    private IEnumerator PowerUpRoutine(float speedMul, float jumpMul, float duration)
    {
        // ������Ԃɂ���
        speed = defaultSpeed * speedMul;
        jumpForce = defaultJumpForce * jumpMul;

        // �����p�Ƀ��O
        Debug.Log($"<color=yellow>PowerUp�I speed={speed}, jumpForce={jumpForce}</color>");

        // �p�����ԑҋ@
        yield return new WaitForSeconds(duration);

        // ���ɖ߂�
        speed = defaultSpeed;
        jumpForce = defaultJumpForce;
        Debug.Log("<color=yellow>PowerUp����</color>");

        powerUpCoroutine = null;
    }
}
