using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;

    private Camera _camera;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out var hitInfo, 50f);
            
        if (Input.GetMouseButton(0))
        {
            _destination = hitInfo.point;
        }

        // Перемещаем персонажа в направлении _destination.
        _navMeshAgent.SetDestination(_destination);

        // TODO: Получите точку, по которой кликнули мышью и задайте ее вектор в поле _destination.
    }
}