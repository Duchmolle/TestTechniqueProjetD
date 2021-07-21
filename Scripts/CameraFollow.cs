using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _offSet;

    private void FixedUpdate()
    {
        Vector3 finalPos = _player.position + _offSet;
        Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, _smoothSpeed* Time.deltaTime);
        transform.position = smoothPos;
    }
}
