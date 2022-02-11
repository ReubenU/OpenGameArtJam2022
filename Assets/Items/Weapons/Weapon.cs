using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // This is where you load
    // the kind of projectile you want
    // to shoot.
    public Projectile bullet;

    public abstract void Fire();
}
