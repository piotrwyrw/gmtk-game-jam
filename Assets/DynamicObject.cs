using System;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

public class DynamicObject : MonoBehaviour {
    private GameObject m_Object;
    private float startXPos = -2;
    private float startYPos = -2;
    private float endXPos = 2;
    private float endYPos = 2;
    private float speedX = 0.1f;
    private float speedY = 0.1f;

    private Vector3 m_initialPosition;
    private bool endXReached;
    private bool endYReached;
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _boxCollider2D;

    // Start is called before the first frame update
    void Start() {
        m_Object = gameObject;
        _rigidbody2D = this.AddIfNotPresent<Rigidbody2D>();
        _rigidbody2D.gravityScale =
            0.0f; // Disable the gravity on the platform so we won't experience any weird behaviour
        _rigidbody2D.freezeRotation = true;
        _rigidbody2D.mass = float.MaxValue;

        _boxCollider2D = this.AddIfNotPresent<BoxCollider2D>();

        endXReached = false;
        endYReached = false;
        m_initialPosition = m_Object.transform.position;
        Transform transform = m_Object.transform;
        m_Object.transform.position = new Vector3(transform.position.x + startXPos, transform.position.y + startYPos,
            transform.position.z);
    }

    private void FixedUpdate() {
        Vector3 position = m_Object.transform.position;

        if ((position.x <= m_initialPosition.x + endXPos) && !endXReached)
            m_Object.transform.position += new Vector3(speedX, 0, 0);
        else
            endXReached = true;

        if ((position.y <= m_initialPosition.y + endYPos) && !endYReached)
            m_Object.transform.position += new Vector3(0, speedY, 0);
        else
            endYReached = true;


        if ((position.x >= m_initialPosition.x + startXPos) && endXReached)
            m_Object.transform.position += new Vector3(-speedX, 0, 0);
        else
            endXReached = false;

        if ((position.y >= m_initialPosition.y + startYPos) && endYReached)
            m_Object.transform.position += new Vector3(0, -speedY, 0);
        else
            endYReached = false;
    }
}