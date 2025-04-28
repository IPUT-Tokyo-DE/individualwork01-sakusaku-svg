using UnityEngine;

public class PowerUpItem : MonoBehaviour
{
    [Header("このアイテム固有の強化値")]
    public float speedMultiplier = 2f;
    public float jumpMultiplier = 1.5f;
    public float duration = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var controller = other.GetComponent<CharacterController2D>();
            if (controller != null)
            {
                controller.StartPowerUp(speedMultiplier, jumpMultiplier, duration);
            }
            Destroy(gameObject);
        }
    }
}
