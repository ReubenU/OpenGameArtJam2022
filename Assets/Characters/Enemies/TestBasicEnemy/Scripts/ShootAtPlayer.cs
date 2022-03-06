
using UnityEngine;

public class ShootAtPlayer : Weapon
{
    public Transform playerTransform;

    public float shootCadence = 0.5f; // In seconds
    private float cadenceCount = 0;

    public float sightFieldAngle = 15f; // in degrees
    public float maxDistance = 10f;

    public float maxBulletLife = 3f;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    public override void Fire()
    {
        Vector3 lookDirection = playerTransform.position - transform.position;

        float angle = Vector3.Angle(transform.TransformDirection(Vector3.forward), lookDirection.normalized);

        if (angle <= sightFieldAngle && lookDirection.magnitude <= maxDistance)
        {
            if (cadenceCount > shootCadence)
            {
                GameObject newBullet = Instantiate(bullet.gameObject, transform.position, transform.rotation);

                Destroy(newBullet, maxBulletLife);

                cadenceCount = 0;
            }

            cadenceCount += Time.deltaTime;
        }
    }
}
