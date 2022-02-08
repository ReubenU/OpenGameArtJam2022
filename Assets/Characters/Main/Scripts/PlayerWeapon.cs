using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : Weapon
{
    public Projectile ricochetBullet;

    PlayerInputActions playerInput;
    InputAction fireWeapon;

    void Awake()
    {
        playerInput = new PlayerInputActions();
        fireWeapon = playerInput.Player.Fire;

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
        if (fireWeapon.triggered)
        {
            Instantiate(bullet.gameObject, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Switch weapon to other arsenal.
    public void SwitchWeapon(Projectile otherWeapon)
    {
        bullet = otherWeapon;
    }
}
