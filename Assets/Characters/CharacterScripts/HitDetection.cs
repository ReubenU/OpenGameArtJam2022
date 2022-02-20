
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public EntityStateManager entityStateManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Projectile"))
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>();

            entityStateManager.health -= bullet.damage;

            Destroy(bullet.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag.Equals("Projectile"))
        {
            Projectile bullet = collision.gameObject.GetComponent<Projectile>();

            entityStateManager.health -= bullet.damage;

            Destroy(bullet.gameObject);
        }
    }
}
