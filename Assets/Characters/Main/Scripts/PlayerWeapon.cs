using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : Weapon
{
    // Our weapon controls are defined here
    PlayerInputActions playerInput;
    InputAction fireWeapon;

    // Define all available projectiles here
    public Projectile ricochetBullet;

    public float maxBulletLife = 3f;


    void Awake()
    {
        playerInput = new PlayerInputActions();
        fireWeapon = playerInput.Player.Fire;

        // Set a starting weapon. Can be null
        bullet = ricochetBullet;
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
        Fire();
    }

    // When firing the player's weapon, the weapon game object
    // will spawn a new projectile game object.
    // Depending on the kind of Projectile, the bullet would
    // either fly off or parent itself with the gun like a laser
    // beam.
    public override void Fire()
    {
        if (fireWeapon.triggered && bullet != null)
        {
            GameObject newBullet = Instantiate(bullet.gameObject, gameObject.transform.position, gameObject.transform.rotation);

            Destroy(newBullet, maxBulletLife);
        }
    }

    // Switch weapon to other arsenal.
    public void SwitchWeapon(Projectile otherWeapon)
    {
        bullet = otherWeapon;
    }
}
