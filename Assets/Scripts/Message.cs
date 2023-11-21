using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField] private GameObject _text;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _text.SetActive(false);
        }
    }
}