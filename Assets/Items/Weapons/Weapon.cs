using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Projectile bullet;

    public abstract void Fire();
}
