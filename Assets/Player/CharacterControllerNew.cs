using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerNew : MonoBehaviour {

    private InputActionManager _inputActionManager;
    private Vector2 _velocity;
    private Rigidbody2D _rigidbody;

    
    
    private void Awake() {
        this._inputActionManager = new InputActionManager();
        this._velocity = new Vector2(0, 0);
        this._rigidbody = GetComponent<Rigidbody2D>();

        this._inputActionManager.Player.ChangeGravity.performed += OnChangeGravity;
    }

    private void OnChangeGravity(InputAction.CallbackContext callbackContext) {

        float targetGravityScale = _rigidbody.gravityScale * -1;
        const float tolerance = 0.01f;
        
        while (Math.Abs(_rigidbody.gravityScale - targetGravityScale) > tolerance) {
            if (targetGravityScale < 1) {
                _rigidbody.gravityScale--;
                continue;
            }

            _rigidbody.gravityScale++;
        }

    }

    private void OnEnable() {
        this._inputActionManager.Enable();
    }

    private void OnDisable() {
        this._inputActionManager.Disable();
    }
    

    private void FixedUpdate() {
        _rigidbody.velocity = _velocity;
        
    }

}
