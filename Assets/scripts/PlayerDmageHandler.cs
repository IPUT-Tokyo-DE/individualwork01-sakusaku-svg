using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public int damageAmount = 10;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth ��������Ȃ���I");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger����: " + other.name);
        if (other.CompareTag("Unsafe"))
        {
            Debug.Log("Unsafe�i2D Trigger�j�ɓ��������I");
            playerHealth.TakeDamage(damageAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision����: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Unsafe"))
        {
            Debug.Log("Unsafe�i2D Collision�j�ɓ��������I");
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
