using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    
    public event Action PlayerDetected;
    public event Action PlayerLost;

    [SerializeField] private Potion _potion;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&_potion.HasPotion()==false)
        {
            PlayerDetected?.Invoke();
           // Debug.Log("Игрок вошел в зону триггера");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&_potion.HasPotion()==true)
        {
            PlayerLost?.Invoke();
            // Debug.Log("Игрок вышел в зону триггера");
        }
    }
    // Todo: сделать второй тригер и повесить включение огня туда. а этот оставить на разрушение моста.
}
