using System;
using UnityEngine;

public class СharacterMovement : MonoBehaviour
{
    private IA_GameControls _gameControls;

    /// <summary>
    /// Border of X axis in percentage of screen. x - left border, y - right border
    /// </summary>
    [SerializeField] private Vector2 bordersViewportX;

    /// <summary>
    /// Border of Y axis in percentage of screen. x - left border, y - right border
    /// </summary>
    [SerializeField] private Vector2 bordersViewportY;

    private float _minBorderXCoordinate, _maxBorderXCoordinate, _minBorderYCoordinate, _maxBorderYCoordinate;

    [SerializeField] private float speed;
    
    #region MonoBehavior Methods

    private void Awake()
    {
        _gameControls = new();
        
        Camera mainCamera = Camera.main;

        _minBorderXCoordinate = mainCamera.ViewportToWorldPoint(new Vector3(bordersViewportX.x, 0, 0)).x;
        _maxBorderXCoordinate = mainCamera.ViewportToWorldPoint(new Vector3(bordersViewportX.y, 0, 0)).x;

        _minBorderYCoordinate = mainCamera.ViewportToWorldPoint(new Vector3(0, bordersViewportY.x, 0)).y;
        _maxBorderYCoordinate = mainCamera.ViewportToWorldPoint(new Vector3(0, bordersViewportY.y, 0)).y;
    }

    private void OnEnable()
    {
        _gameControls.Enable();
    }

    private void Update()
    {
        Vector2 moveInput = _gameControls.Character.Move.ReadValue<Vector2>();
        Vector3 movement = moveInput * (Time.deltaTime * speed);

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + movement;

        newPosition.x = Mathf.Clamp(newPosition.x, _minBorderXCoordinate, _maxBorderXCoordinate);
        newPosition.y = Mathf.Clamp(newPosition.y, _minBorderYCoordinate, _maxBorderYCoordinate);

        transform.position = newPosition;

        Vector3 characterPosition = transform.position;
    }

    private void OnDisable()
    {
        _gameControls.Disable();
    }

    #endregion
    
}
