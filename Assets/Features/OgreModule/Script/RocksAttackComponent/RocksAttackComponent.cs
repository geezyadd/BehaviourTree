using System.Collections;
using UnityEngine;

public class RocksAttackComponent : MonoBehaviour
{
    [SerializeField] private BoidSpawner _boidSpawner;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _player;
    
    public void StartRockAttack()
    {
        StartCoroutine(SpawnRocksWithDelay());
    }

    private IEnumerator SpawnRocksWithDelay()
    {
        _animator.SetTrigger("Flexing");
        yield return new WaitForSeconds(3f);
        _animator.SetTrigger("BreakDance");
        yield return new WaitForSeconds(3f);
        _boidSpawner.SpawnBoids();
        yield return new WaitForSeconds(3f);
        foreach (Boid boid in _boidSpawner.ActiveBoids)
        {
            boid.Attack(_player);
            yield return new WaitForSeconds(1f);
        }
    }
}
