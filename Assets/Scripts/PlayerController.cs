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
    [SerializeField] float touchSensitivity = 1f;

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

void MovePlayer()
{
    Vector2 input = moveAction.ReadValue<Vector2>();
    Vector3 newPos = transform.position;
    var control = moveAction.activeControl;

    if (control != null && control.device is Touchscreen)
    {
        // Parmak (ya da simüle fare): piksel -> dünya birimi, deltaTime yok
        float worldPerPixel = (maxBounds.y - minBounds.y) / Screen.height;
        newPos += (Vector3)(input * worldPerPixel * touchSensitivity);
    }
    else
    {
        // WASD ve gamepad
        newPos += (Vector3)input * moveSpeed * Time.deltaTime;
    }

    newPos.x = Math.Clamp(newPos.x, minBounds.x + leftPadding, maxBounds.x - rightPadding);
    newPos.y = Math.Clamp(newPos.y, minBounds.y + bottomPadding, maxBounds.y - upPadding);

    transform.position = newPos;
}

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }


}
