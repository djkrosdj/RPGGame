using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    
    public event Action PlayerDetected;
    public event Action PlayerLost;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected?.Invoke();
           // Debug.Log("Игрок вошел в зону триггера");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLost?.Invoke();
            // Debug.Log("Игрок вышел в зону триггера");
        }
    }
}
