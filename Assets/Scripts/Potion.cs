using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Potion : MonoBehaviour
{
    private bool _hasPlayerPickedUpPotion;

    [SerializeField] private Outline _outlinePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _hasPlayerPickedUpPotion = true;
            Destroy(gameObject);
            _outlinePlayer.OutlineWidth = 2f;
        }
    }

    public bool HasPotion()
    {
        return _hasPlayerPickedUpPotion;
    }
    
    // Todo: Оставить зелье чисто тригером, Создать класс плеер и перенести туда логику взятия зелья и включение свечения игрока.

}