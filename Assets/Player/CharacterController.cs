using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterController : MonoBehaviour
{
    private InputActionManager controls;
    Vector2 move = Vector2.zero;
    Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed = 5f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move = controls.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(move.x * movementSpeed * Time.fixedDeltaTime, rigidbody.velocity.y);
    }

    private void Awake()
    {
        controls = new InputActionManager();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
