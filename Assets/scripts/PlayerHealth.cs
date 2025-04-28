using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("�̗͐ݒ�")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("���X�|�[���ݒ�")]
    public Transform respawnPoint;
    public float respawnDelay = 3f;

    [Header("�Q�[���I�[�o�[UI")]
    public GameObject gameOverUI;

    [Header("UI�\��")]
    public Slider healthSlider;   // HealthSlider �������Ƀh���b�O
    public TMP_Text healthText;       // HealthText �������Ƀh���b�O

    [HideInInspector]
    public bool isDead = false;

    [Header("�p���_���[�W�ݒ�")]
    public string hazardTag = "Hazard";     // �댯�n�т̃^�O��
    public int damagePerTick = 5;            // 1��̃_���[�W��
    public float damageInterval = 1f;           // �_���[�W�Ԋu�i�b�j

    private bool isInHazard = false;        // �ڐG���t���O


    public void Start()
    {
        // �̗͏�����
        currentHealth = maxHealth;

        // UI �����ݒ�
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (healthText != null)
            healthText.text = $"{currentHealth} / {maxHealth}";

        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }


    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"�_���[�W�I �c��HP: {currentHealth}");

        // UI �X�V
        if (healthSlider != null)
            healthSlider.value = currentHealth;
        if (healthText != null)
            healthText.text = $"{currentHealth} / {maxHealth}";

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // UI �X�V
        if (healthSlider != null)
            healthSlider.value = currentHealth;
        if (healthText != null)
            healthText.text = $"{currentHealth} / {maxHealth}";
    }

    public void Die()
    {
        isDead = true;
        Debug.Log("�v���C���[�����ꂽ�I�i�Q�[���I�[�o�[�j");

        // �����蔻��E�����E�\�����I�t
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<SpriteRenderer>().enabled = false;

        // �Q�[���I�[�o�[UI�\��
        if (gameOverUI != null)
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);

    }

    // ���g���C�{�^������Ăяo��
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // �^�C�g���֖߂�{�^������Ăяo��
    public void GoToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageSelect");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDead && other.CompareTag(hazardTag))
        {
            isInHazard = true;
            StartCoroutine(ApplyDamageOverTime());
        }
    }

    // �g���K�[����o����_���[�W��~
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(hazardTag))
        {
            isInHazard = false;
            StopCoroutine(ApplyDamageOverTime());
        }
    }

    // �ڐG���AdamageInterval ���ƂɃ_���[�W��^����
    private IEnumerator ApplyDamageOverTime()
    {
        while (isInHazard)
        {
            TakeDamage(damagePerTick);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
