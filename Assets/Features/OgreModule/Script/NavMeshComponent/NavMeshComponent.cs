using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshComponent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }

    public void SetRotationSpeed(float speed)
    {
        _agent.angularSpeed = speed;
    }

    public void EnableNavMeshAgent(bool enable)
    {
        _agent.enabled = enable;
    }

    public void SetDestination(Vector3 position)
    {
        _agent.SetDestination(position);
    }

    public void ResetPath()
    {
        _agent.ResetPath();
    }
}
