using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public GameObject effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HeartUI.instance.AddHeart(); // 👈 suma 1

            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
