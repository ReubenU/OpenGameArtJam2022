using UnityEngine;

public abstract class EntityStateManager : MonoBehaviour
{
    public float health = 100;

    public Rigidbody rigid;

    public float moveSpeed;
    public float boostSpeed;
}
