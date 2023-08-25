using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float steerAmount;
    [SerializeField] private float moveAmount;
    
    void Update()
    {
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        transform.Rotate(0 , 0 , -steerAmount);
        moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
    }
}
