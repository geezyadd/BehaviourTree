using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    public event Action<Vector2> OnMove;

    private void OnMovement(InputValue value)
    {
        OnMove?.Invoke(value.Get<Vector2>());
    }
}
