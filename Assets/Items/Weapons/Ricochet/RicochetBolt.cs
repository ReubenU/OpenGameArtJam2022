using UnityEngine;

public class RicochetBolt : Projectile
{

    private void Awake()
    {
        bulletBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bulletBody.AddRelativeForce(
            (Vector3.forward * muzzleVelocity)-transform.InverseTransformDirection(bulletBody.velocity),
            ForceMode.VelocityChange
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("LevelCollision"))
        {
            if (collision.contactCount > 0)
            {
                Vector3 contactPoint = collision.GetContact(0).point;
                Vector3 contactNormal = collision.GetContact(0).normal;

                Vector3 reflect = Vector3.Reflect(transform.TransformDirection(Vector3.forward), contactNormal);


                //transform.Translate(reflect * 0.1f, Space.World);
                transform.position = contactPoint + (reflect.normalized * 0.5f);
                transform.LookAt(contactPoint + reflect, Vector3.up);
            }
        }
    }
}
