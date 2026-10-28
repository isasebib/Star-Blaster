using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector3 moveVector;
    [SerializeField] float moveSpeed = 25f;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float leftPadding = 1f;
    [SerializeField] float rightPadding = 1f;
    [SerializeField] float bottomPadding = 1f;
    [SerializeField] float upPadding = 15f;

    Shooter playerShooter;
    InputAction moveAction;
    InputAction fireAction;

    void Start()
    {
        playerShooter = GetComponent<Shooter>();

        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");

        InitBounds();

    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2 (0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2 (1,1));
    }

    void Update()
    {
        MovePlayer();
        FireShooter();
    }

    void MovePlayer() {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Math.Clamp(newPos.x, minBounds.x + leftPadding , maxBounds.x - rightPadding);
        newPos.y = Math.Clamp(newPos.y, minBounds.y + bottomPadding, maxBounds.y - upPadding);

        transform.position = newPos;
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }


}
