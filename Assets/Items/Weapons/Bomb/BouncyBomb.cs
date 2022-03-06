using UnityEngine;

public class BouncyBomb : Projectile
{

    private void Awake()
    {
        bulletBody.AddForce(muzzleVelocity * Vector3.forward, ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("LevelCollision"))
        {
            if (collision.contactCount > 0)
            {
                Vector3 contactNormal = collision.GetContact(0).normal;

                Vector3 reflect = Vector3.Reflect(transform.TransformDirection(Vector3.forward), contactNormal);


                transform.Translate(reflect * 0.1f, Space.World);

                bulletBody.AddForce(reflect * bulletBody.velocity.magnitude, ForceMode.Impulse);
            }
        }
    }
}
