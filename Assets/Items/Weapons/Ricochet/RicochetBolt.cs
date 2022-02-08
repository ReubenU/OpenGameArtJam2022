using UnityEngine;

public class RicochetBolt : Projectile
{
    float ttk = 0f;


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

        ttk += Time.deltaTime;

        if (ttk >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
