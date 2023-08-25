using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    
    void LateUpdate()
    {
        transform.position = _target.transform.position + new Vector3(0, 0, -10);
    }
}
