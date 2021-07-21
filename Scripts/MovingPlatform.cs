using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            _player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _player.transform.parent = null;
    }
}
