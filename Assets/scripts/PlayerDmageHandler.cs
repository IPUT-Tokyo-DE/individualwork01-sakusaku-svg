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
            Debug.LogError("PlayerHealth が見つからないよ！");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger相手: " + other.name);
        if (other.CompareTag("Unsafe"))
        {
            Debug.Log("Unsafe（2D Trigger）に当たった！");
            playerHealth.TakeDamage(damageAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision相手: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Unsafe"))
        {
            Debug.Log("Unsafe（2D Collision）に当たった！");
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
