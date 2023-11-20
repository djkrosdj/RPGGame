using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    
    private Detector _detector;
    private bool IsTheBridgeBroken = false;
    
    [SerializeField] private GameObject _fire;

    private float _minForceValue = 150;
    private float _maxForceValue = 200;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        // Находим детектор на сцене
        _detector = FindObjectOfType<Detector>();

        if (_detector != null)
        {
            _detector.PlayerDetected += Break;
        }

        if (!IsTheBridgeBroken)
        {
            _detector.PlayerLost += LightIsOn;
        }
    }

    private void OnDisable()
    {
        _detector.PlayerDetected -= Break;
        _detector.PlayerLost -= LightIsOn;
    }


    public void Break()
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
    
    private void LightIsOn()
    {
        _fire.SetActive(true);
    }
}