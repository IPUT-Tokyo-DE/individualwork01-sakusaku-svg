using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("体力設定")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("リスポーン設定")]
    public Transform respawnPoint;
    public float respawnDelay = 3f;

    [Header("ゲームオーバーUI")]
    public GameObject gameOverUI;

    [Header("UI表示")]
    public Slider healthSlider;   // HealthSlider をここにドラッグ
    public TMP_Text healthText;       // HealthText をここにドラッグ

    [HideInInspector]
    public bool isDead = false;

    [Header("継続ダメージ設定")]
    public string hazardTag = "Hazard";     // 危険地帯のタグ名
    public int damagePerTick = 5;            // 1回のダメージ量
    public float damageInterval = 1f;           // ダメージ間隔（秒）

    private bool isInHazard = false;        // 接触中フラグ


    public void Start()
    {
        // 体力初期化
        currentHealth = maxHealth;

        // UI 初期設定
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

        Debug.Log($"ダメージ！ 残りHP: {currentHealth}");

        // UI 更新
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

        // UI 更新
        if (healthSlider != null)
            healthSlider.value = currentHealth;
        if (healthText != null)
            healthText.text = $"{currentHealth} / {maxHealth}";
    }

    public void Die()
    {
        isDead = true;
        Debug.Log("プレイヤーがやられた！（ゲームオーバー）");

        // 当たり判定・物理・表示をオフ
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<SpriteRenderer>().enabled = false;

        // ゲームオーバーUI表示
        if (gameOverUI != null)
            Time.timeScale = 0f;
            gameOverUI.SetActive(true);

    }

    // リトライボタンから呼び出す
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // タイトルへ戻るボタンから呼び出し
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

    // トリガーから出たらダメージ停止
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(hazardTag))
        {
            isInHazard = false;
            StopCoroutine(ApplyDamageOverTime());
        }
    }

    // 接触中、damageInterval ごとにダメージを与える
    private IEnumerator ApplyDamageOverTime()
    {
        while (isInHazard)
        {
            TakeDamage(damagePerTick);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
