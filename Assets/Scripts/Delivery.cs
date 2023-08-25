using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    
    [Header("Color")] 
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);
    private SpriteRenderer spriteRenderer;

    [Header("Time")]
    [SerializeField] private float destroyDelay;
    
    private bool hasPackage = false; //At the start, delivery has no package.

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");

            hasPackage = true;

            spriteRenderer.color = hasPackageColor;
            
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");

            hasPackage = false;
            
            spriteRenderer.color = noPackageColor;
        }
    }
}
