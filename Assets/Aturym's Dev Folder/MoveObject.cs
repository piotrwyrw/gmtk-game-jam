using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] GameObject m_Object;
    [SerializeField] float startXPos = -2;
    [SerializeField] float startYPos = -2;
    [SerializeField] float endXPos = 2;
    [SerializeField] float endYPos = 2;
    [SerializeField] float speedX = 0.1f;
    [SerializeField] float speedY = 0.1f;

    private Vector3 m_initialPosition;
    [SerializeField] private bool endXReached;
    [SerializeField] private bool endYReached;

    // Start is called before the first frame update
    void Start()
    {
        //m_Object = GetComponent<GameObject>();
        endXReached = false;
        endYReached = false;
        m_initialPosition = m_Object.transform.position;
        Transform transform = m_Object.transform;
        m_Object.transform.position = new Vector3(transform.position.x + startXPos, transform.position.y + startYPos, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 position = m_Object.transform.position;
        if((position.x <= m_initialPosition.x + endXPos) && !endXReached)
        {
            m_Object.transform.position = addToVector(m_Object.transform.position, new Vector3(speedX, 0, 0));
        }
        else
        {
            endXReached = true;
            //Debug.Log("End X Reached");
        }
        if((position.y <= m_initialPosition.y + endYPos) && !endYReached)
        {
            m_Object.transform.position = addToVector(m_Object.transform.position, new Vector3(0, speedY, 0));
        }
        else
        {
            endYReached = true;
            //Debug.Log("End Y Reached");
        }

        
        if((position.x >= m_initialPosition.x + startXPos) && endXReached)
        {
            m_Object.transform.position = addToVector(m_Object.transform.position, new Vector3(-speedX, 0, 0));
        }
        else
        {
            endXReached = false;
        }
        if((position.y >= m_initialPosition.y + startYPos) && endYReached)
        {
            m_Object.transform.position = addToVector(m_Object.transform.position, new Vector3(0, -speedY, 0));
        }
        else
        {
            endYReached = false;
        }
    }

    public Vector3 addToVector(Vector3 pos, Vector3 add)
    {
        return new Vector3(pos.x + add.x, pos.y + add.y, pos.z + add.z);
    }
}
