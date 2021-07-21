using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsManager : MonoBehaviour
{
    [SerializeField] Transform _center;
    [SerializeField] Vector3 _halfExtent;
    Collider[] _colliderBuffer = new Collider[1];
    [SerializeField] LayerMask _whatIsGround;
    [SerializeField] Color _color;
    public bool IsGrounded()
    {
        return Physics.OverlapBoxNonAlloc(_center.position, _halfExtent, _colliderBuffer, Quaternion.identity, _whatIsGround) > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;

        Gizmos.DrawWireCube(_center.position, _halfExtent * 2);
    }
}
