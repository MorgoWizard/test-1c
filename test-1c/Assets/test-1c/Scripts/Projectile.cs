using UnityEngine;

public class Projectile : MonoBehaviour
{
    // TODO: destroy when get out from view
    public int bulletDamage = 10;
    public float speed = 10f;

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<IDamageable>(out IDamageable enemyHealth))
        {
            enemyHealth.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
