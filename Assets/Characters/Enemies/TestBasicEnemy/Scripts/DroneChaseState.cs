using UnityEngine;


public class DroneChaseState : DroneBaseState
{
    private EntityStateManager _stateManager;

    private Transform _target;
    private Rigidbody _rigid;

    private float _maxDistance;

    public DroneChaseState(EntityStateManager entityStateManager, Transform target, float maxDistance) : base(entityStateManager)
    {
        _stateManager = entityStateManager;

        _target = target;

        _rigid = entityStateManager.GetComponent<Rigidbody>();

        _maxDistance = maxDistance;
    }

    public override void UpdateState()
    {
        MaintainDistance();
    }

    void MaintainDistance()
    {
        RaycastHit hitInfo;

        Vector3 origin = _stateManager.transform.position;

        Physics.Raycast(origin, _target.position - origin, out hitInfo);

        if (hitInfo.collider.transform == _target)
        {
            Vector3 direction = (_target.position - origin).normalized;
            float delta = (_target.position - origin).magnitude - _maxDistance;

            delta = Mathf.Clamp(delta, -1, 1);

            _rigid.AddForce((direction * _stateManager.moveSpeed * delta)-_rigid.velocity, ForceMode.VelocityChange);
        }
    }
}
