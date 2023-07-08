using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerNew : MonoBehaviour
{

    private InputActionManager _inputActionManager;
    private Vector2 _velocity;
    private Rigidbody2D _rigidbody;
    private PlayerGravityChangeInputCooldown _inputCooldown;
    [SerializeField] private Vector2 gravity;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }


    private void Awake()
    {
        this._inputActionManager = new InputActionManager();
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

    private void OnChangeGravity(InputAction.CallbackContext callbackContext)
    {

        Debug.Log("OnChangeGravity() reached");

        if (this.gravity.y < 0)
        {
            this.gravity = new Vector2(0, 9.81f);
        }
        else
            this.gravity = new Vector2(0, -9.81f);

    }


    private void OnEnable()
    {
        this._inputActionManager.Enable();
    }

    private void OnDisable()
    {
        this._inputActionManager.Disable();
    }

    private void LateUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }
}