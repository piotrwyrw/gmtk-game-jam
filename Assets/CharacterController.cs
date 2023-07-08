using System;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    private InputActionManager controls;
    Vector2 move = Vector2.zero;
    Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed = 30f;
    private Camera camera;

    private void Start() {
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        move = controls.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rigidbody.velocity = new Vector2(move.x * movementSpeed * Time.fixedDeltaTime, rigidbody.velocity.y);
    }

    private void LateUpdate() {
        camera.transform.position =
            new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }

    private void Awake() {
        controls = new InputActionManager();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }
}