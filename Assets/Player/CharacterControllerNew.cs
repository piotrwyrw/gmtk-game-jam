using System;
using System.Collections;
using System.Linq;
using Extensions.Buttons;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CharacterControllerNew : MonoBehaviour {
    private InputActionManager _inputActionManager;
    private Vector2 _velocity;
    private Rigidbody2D _rigidbody;
    private PlayerGravityChangeInputCooldown _inputCooldown;

    [SerializeField] private Vector2 gravity = new Vector2(0, -9.81f);
    [SerializeField] private GravityChange gravityChange = GravityChange.None;
    [SerializeField] private float gravityDerivativeModificationDelta = 1;
    [SerializeField] private bool shouldWaitForChangeGravityToBeNone = true;
    [SerializeField] private float gravitationChangeDelta = 1;
    [SerializeField] private float fixedCameraPositionY = 0;
    [SerializeField] private float fixedCameraPositionX = 0;
    [SerializeField] private bool cameraFollowPlayer = true;
    [SerializeField] private bool cameraFollowPlayerX = true;
    [SerializeField] private bool cameraFollowPlayerY = true;

    public GameObject gameOverMenu;
    public GameObject gameCompleteMenu;
    public GameObject gameEscapeMenu;

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


        this._inputActionManager.Player.ChangeGravity.performed += OnChangeGravity;

    }


    private void OnChangeGravity(InputAction.CallbackContext callbackContext) {
        if (gravityChange != GravityChange.None && this.shouldWaitForChangeGravityToBeNone)
            return;

        if (this.gravity.y < 0) {
            this.gravityChange = GravityChange.Up;
        }
        else {
            this.gravityChange = GravityChange.Down;
        }
        
        onSpacePressed?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameCompleteMenu.activeSelf && !gameOverMenu.activeSelf) {
                gameEscapeMenu.SetActive(true);
            }
        }
    }


    private void OnEnable() {
        this._inputActionManager.Enable();
    }

    private void OnDisable() {
        this._inputActionManager.Disable();
    }

    private void LateUpdate() {
        Vector3 position = camera.transform.position;

        var position1 = transform.position;

        position = new Vector3(cameraFollowPlayerX ? position1.x : fixedCameraPositionX,
            cameraFollowPlayerY ? position1.y : fixedCameraPositionY, position.z);

        if (cameraFollowPlayer)
            camera.transform.position = position;
    }


    private void FixedUpdate() {
        Physics2D.gravity = gravity;
        _rigidbody.velocity = new Vector2(2, 0);

        if (gravityChange == GravityChange.Up) {
            if (gravity.y > 0)
                gravity.y += gravitationChangeDelta;
            gravity.y += gravityDerivativeModificationDelta;

            if (gravity.y >= 9.81) {
                gravity.y = 9.81f;
                gravityChange = GravityChange.None;
            }
        }

        if (gravityChange == GravityChange.Down) {
            if (gravity.y > 0)
                gravity.y -= gravitationChangeDelta;
            gravity.y -= gravityDerivativeModificationDelta;


            if (gravity.y <= -9.81) {
                gravity.y = -9.81f;
                gravityChange = GravityChange.None;
            }
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            this._velocity = new Vector2(0, 0);

            if (!gameCompleteMenu.activeSelf) {
                gameOverMenu.SetActive(true);
            }
            gameEscapeMenu.SetActive(false);
        }

        if (collision.gameObject.layer == 7)
        {
            if (!gameOverMenu.activeSelf) {
                gameCompleteMenu.SetActive(true);
            } 
            gameEscapeMenu.SetActive(false);
        }
    }



    public enum GravityChange {
        Up,
        Down,
        None
    }

    public void KillPlayer() {
        
    }

}