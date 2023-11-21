using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorFire : MonoBehaviour
{
    public event Action PlayerLost;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerLost?.Invoke();
            // Debug.Log("Игрок вышел из зоны триггера");
        }
    }
}