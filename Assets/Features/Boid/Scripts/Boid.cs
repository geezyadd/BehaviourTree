using UnityEngine;

public class Boid : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _attackSpeed = 100f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _checkNeighboursRadius = 10f;
    private float _aligmentMultiplier;
    private float _cohesionMultiplier;
    private float _separationMultiplier;
    private GameObject _leader;
    private bool _isAttackState;
    private Vector3 _attackDirection;
    private GameObject _target;

    public void SetValuesMultiplier(float aligmentMultiplier, float cohesionMultiplier, float separationMultiplier)
    {
        _aligmentMultiplier = aligmentMultiplier;
        _cohesionMultiplier = cohesionMultiplier;
        _separationMultiplier = separationMultiplier;
    }

    public void SetLeader(GameObject leader)
    {
        _leader = leader;
    }

    public void Attack(GameObject target)
    {
        _target = target;
        _isAttackState = true;
        _attackDirection = (_target.transform.position - transform.position).normalized;
    }

    private void Update()
    {
        if (_isAttackState)
        {
            if (_target != null)
            {
                Vector3 newPosition = transform.position + _attackDirection * _attackSpeed * Time.deltaTime;

                transform.position = newPosition;

            }
            return;
        }
        BoidsMove();
    }

    private void BoidsMove()
    {
        Vector3 aligment = Vector3.zero;
        Vector3 cohesion = Vector3.zero;
        Vector3 separation = Vector3.zero;

        int count = 0;
        Collider[] neghbors = Physics.OverlapSphere(transform.position, _checkNeighboursRadius);

        foreach (Collider neighbor in neghbors)
        {
            if (neighbor.gameObject != gameObject)
            {
                Boid neighborBoid = neighbor.GetComponent<Boid>();
                if (neighborBoid != null)
                {
                    aligment += neighborBoid.transform.forward;
                    cohesion += neighborBoid.transform.position;
                    Vector3 directionToneighbor = transform.position - neighborBoid.transform.position;
                    separation += directionToneighbor.normalized / directionToneighbor.magnitude;
                }
                count++;
            }
        }

        if (count > 0)
        {
            aligment /= count;
            cohesion = (cohesion / count - transform.position).normalized;
            separation /= count;
        }


        Vector3 directionToLeader = Vector3.zero;
        if (_leader != null)
        {
            directionToLeader = (_leader.transform.position - transform.position).normalized;
        }

        Vector3 moveDirection = aligment * _aligmentMultiplier + cohesion * _cohesionMultiplier + separation * _separationMultiplier + directionToLeader;
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }

}
