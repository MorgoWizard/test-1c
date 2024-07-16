using System;
using UnityEngine;

public class СharacterMovement : MonoBehaviour
{
    private IA_GameControls _gameControls;

    private Camera _mainCamera;

    [SerializeField] private Vector2 bordersX, bordersY;

    [SerializeField] private float speed;
    
    #region MonoBehavior Methods

    private void Awake()
    {
        _gameControls = new();
        
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _gameControls.Enable();
    }

    private void Update()
    {
        Vector2 moveInput = _gameControls.Character.Move.ReadValue<Vector2>();
        Vector3 movement = moveInput * (Time.deltaTime * speed);

        transform.position += movement;

        Vector3 characterPosition = transform.position;
        Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(characterPosition);
    }

    private void OnDisable()
    {
        _gameControls.Disable();
    }

    #endregion
    
}
