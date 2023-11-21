using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorBridge : MonoBehaviour
{
    public event Action PlayerDetected;

    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _player.HasPotion() == false)
        {
            PlayerDetected?.Invoke();
            // Debug.Log("Игрок вошел в зону триггера");
        }
    }
}