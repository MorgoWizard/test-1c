using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private int DamagePerEnemy;

    [SerializeField] private CharacterHealth CharacterHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CharacterHealth.TakeDamage(DamagePerEnemy);
            Destroy(collision.gameObject);
        }
    }
}
