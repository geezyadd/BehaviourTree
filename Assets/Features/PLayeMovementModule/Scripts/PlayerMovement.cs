using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputReader _playerInputReader;
    [SerializeField] private Rigidbody _playerRB;
    [SerializeField] private float _speed;
    [SerializeField] private Camera _playerCamera;
    private Vector2 _movement;

    private void OnEnable()
    {
        _playerInputReader.OnMove += SetInput;
    }

    private void OnDisable()
    {
        _playerInputReader.OnMove -= SetInput;
    }

    private void SetInput(Vector2 vector)
    {
        _movement = vector;
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = _playerCamera.transform.forward;
        Vector3 cameraRight = _playerCamera.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();
        Vector3 MovementDirection = cameraForward * _movement.y + cameraRight * _movement.x;
        _playerRB.velocity = MovementDirection.normalized * _speed;
    }
}
