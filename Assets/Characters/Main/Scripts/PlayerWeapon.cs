using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : Weapon
{
    // Our weapon controls are defined here
    PlayerInputActions playerInput;
    InputAction fireWeapon;

    // Define all available projectiles here
    public Projectile ricochetBullet;
    public Projectile bouncyBomb;

    public Projectile[] bullets;

    public float maxBulletLife = 3f;


    private bool isFiring = false;

    public float rateOfFire = 0.167f;
    private float fireRateAccum;

    void Awake()
    {
        playerInput = new PlayerInputActions();
        fireWeapon = playerInput.Player.Fire;

        // Set a starting weapon. Can be null
        bullet = ricochetBullet;

        bullets = new Projectile[2] { ricochetBullet, bouncyBomb };

        fireWeapon.started += StartFiring;
        fireWeapon.canceled += StopFiring;

        fireRateAccum = rateOfFire;
    }

    private void OnEnable()
    {
        playerInput.Enable();
        fireWeapon.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
        fireWeapon.Disable();
    }

    private void Update()
    {
        if (isFiring)
        {
            if (fireRateAccum > rateOfFire)
            {
                Fire();
                fireRateAccum = 0f;
            }

            fireRateAccum += Time.deltaTime;
        }
    }

    // When firing the player's weapon, the weapon game object
    // will spawn a new projectile game object.
    // Depending on the kind of Projectile, the bullet would
    // either fly off or parent itself with the gun like a laser
    // beam.
    public override void Fire()
    {
        if (bullet != null)
        {
            GameObject newBullet = Instantiate(bullet.gameObject, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(newBullet, maxBulletLife);
        }
    }


    private void StartFiring(InputAction.CallbackContext context)
    {
        isFiring = true;
    }

    private void StopFiring(InputAction.CallbackContext context)
    {
        isFiring = false;
        fireRateAccum = rateOfFire;
    }


    // Switch weapon to other arsenal.
    public void SwitchWeapon(Projectile otherWeapon)
    {
        bullet = otherWeapon;
    }
}
