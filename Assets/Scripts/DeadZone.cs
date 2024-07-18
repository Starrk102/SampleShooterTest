using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class DeadZone : MonoBehaviour
{
    public Action onTrigger;
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            onTrigger.Invoke();
            Destroy(hitInfo.gameObject);
        }
    }
}
