using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _hasPlayerPickedUpPotion;

    [SerializeField] private Outline _outlinePlayer;

    public bool HasPotion()
    {
        return _hasPlayerPickedUpPotion;
    }

    public void PotionPickedUp()
    {
        _hasPlayerPickedUpPotion = true;
        _outlinePlayer.OutlineWidth = 2f;
    }
}