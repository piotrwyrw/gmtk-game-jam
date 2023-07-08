using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    private InputActionManager controls;
    Vector2 move = Vector2.zero;
    Rigidbody2D rigidbody;
    [SerializeField] private float movementSpeed = 5f;
    Camera cam;
    public GameObject gameOverMenu;
    public GameObject gameCompleteMenu;

    private void Start()
    {
        cam = Camera.main;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //move = controls.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rigidbody.velocity.y);
    }

    private void LateUpdate()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) { 
            gameOverMenu.SetActive(true);
        }

        if (collision.gameObject.layer == 7) { 
            gameCompleteMenu.SetActive(true);
        }
    }
}
