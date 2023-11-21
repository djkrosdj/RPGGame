using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Potion : MonoBehaviour
{
    public bool hasPlayerPickedUpPotion;

    [SerializeField] private Outline _outlinePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasPlayerPickedUpPotion = true;
            Destroy(gameObject);
            _outlinePlayer.OutlineWidth = 2f;
        }
    }

}