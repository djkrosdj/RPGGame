using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;

    [SerializeField] private DetectorBridge _detectorBridge;
    [SerializeField] private DetectorFire _detectorFire;
    [SerializeField] private GameObject _fire;

    private float _minForceValue = 150;
    private float _maxForceValue = 200;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Start()
    {
        if (_detectorBridge != null)
        {
            _detectorBridge.PlayerDetected += Break;
        }

        if (_detectorFire != null)
        {
            _detectorFire.PlayerLost += TurnOnLight;
        }
    }

    private void OnDisable()
    {
        _detectorBridge.PlayerDetected -= Break;
        _detectorFire.PlayerLost += TurnOnLight;
    }


    private void Break()
    {
        // Вырезаем отверстие в навмеш (чтобы игрок там больше не смог пройти)
        _navMeshObstacle.enabled = true;

        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;

            // Генерируем случайную силу.
            var forceValue = Random.Range(_minForceValue, _maxForceValue);

            // Генерируем случайное направление.
            var direction = Random.insideUnitSphere;

            // Придаем силу каждому rigidbody.
            rigidbody.AddForce(direction * forceValue);
        }
    }

    private void TurnOnLight()
    {
        _fire.SetActive(true);
    }
}