using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage;
    public float muzzleVelocity;
    public float lifetime;
    public Rigidbody bulletBody;
}
