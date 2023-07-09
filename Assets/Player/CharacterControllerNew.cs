using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerNew : MonoBehaviour {
    private InputActionManager _inputActionManager;
    private Vector2 _velocity;
    private Rigidbody2D _rigidbody;
    private PlayerGravityChangeInputCooldown _inputCooldown;
    private CapsuleCollider2D _capsuleCollider;
    [SerializeField] private Vector2 gravity;

    private Camera camera;

    public event EventHandler onSpacePressed;

    private void Start() {
        camera = Camera.main;
    }

    private void Awake() {
        this._inputActionManager = new InputActionManager();
        this._velocity = new Vector2(0, 0);
        this._rigidbody = GetComponent<Rigidbody2D>();
        this._inputCooldown = GetComponent<PlayerGravityChangeInputCooldown>();
        this._capsuleCollider = GetComponent<CapsuleCollider2D>();

        this._inputActionManager.Player.ChangeGravity.performed += OnChangeGravity;
    }

    // private void OnChangeGravity(InputAction.CallbackContext callbackContext) {
    //     float targetGravityScale = _rigidbody.gravityScale * -1;
    //     const float tolerance = 0.01f;
    //     
    //     if(_inputCooldown.IsCooledDown()) return;
    //     
    //     _inputCooldown.Cooldown = 0.5f;
    //     while (Math.Abs(_rigidbody.gravityScale - targetGravityScale) > tolerance) {
    //         if (targetGravityScale < 1) {
    //             _rigidbody.gravityScale--;
    //             continue;
    //         }
    //         _rigidbody.gravityScale++;
    //     }
    // }

    private void OnChangeGravity(InputAction.CallbackContext callbackContext) {
        // Debug.Log("OnChangeGravity() reached");

        if (this.gravity.y < 0) {
            this.gravity = new Vector2(0, 9.81f);
        }
        else
            this.gravity = new Vector2(0, -9.81f);

        onSpacePressed?.Invoke(this, EventArgs.Empty);
    }


    private void OnEnable() {
        this._inputActionManager.Enable();
    }

    private void OnDisable() {
        this._inputActionManager.Disable();
    }

    private void LateUpdate() {
        camera.transform.position =
            new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }

    private void FixedUpdate() {
        Physics2D.gravity = gravity;
        _rigidbody.velocity = new Vector2(2, 0);
    }

    public void KillPlayer() { }

    private void Update() {
        if (this._inputActionManager.Player.ChangeGravity.IsPressed()) { }
    }
}