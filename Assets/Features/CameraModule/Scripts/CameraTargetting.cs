using UnityEngine;

public class CameraTargetting : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _rotationSpeed = 2f;

    private void FixedUpdate()
    {
        Vector3 direction = _target.transform.position - _mainCamera.transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        _mainCamera.transform.rotation = Quaternion.Lerp(_mainCamera.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
