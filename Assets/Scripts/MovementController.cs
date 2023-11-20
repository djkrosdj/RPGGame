using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Перемещаем персонажа в направлении _destination.
        _navMeshAgent.SetDestination(_destination);
        
        // TODO: Получите точку, по которой кликнули мышью и задайте ее вектор в поле _destination.
    }
}