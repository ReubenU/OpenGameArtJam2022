
using UnityEngine;

public class DroneAim : DroneBaseState
{
    private Transform _target;
    private Rigidbody targetRigid;
    private Transform _aiming;

    private EntityStateManager _stateManager;

    private float leadPercent = 3f; // How far the robot should aim.
    private float aimSmoothing = 3f; // High the value, the smoother the aim.

    public DroneAim(EntityStateManager stateManager, Transform weaponAiming, Transform target) : base(stateManager)
    {
        _stateManager = stateManager;

        _target = target;
        _aiming = weaponAiming;

        targetRigid = _target.gameObject.GetComponent<Rigidbody>();
    }

    public override void UpdateState()
    {
        AimAtTarget();
    }

    private void AimAtTarget()
    {
        RaycastHit hitInfo;

        Vector3 origin = _stateManager.transform.position;

        Vector3 lookDirection = _target.position - origin;

        Physics.Raycast(origin, lookDirection.normalized, out hitInfo);

        Vector3 lead = targetRigid.velocity.normalized * leadPercent;

        if (hitInfo.collider.transform == _target)
        {
            // mainCamera.rotation = Quaternion.Slerp(mainCamera.rotation, Quaternion.LookRotation(lookDirection), sSpeed * Time.deltaTime);
            _aiming.rotation = Quaternion.Slerp(_aiming.rotation, Quaternion.LookRotation(lookDirection + lead), aimSmoothing * Time.fixedDeltaTime);
        }
    }
}
