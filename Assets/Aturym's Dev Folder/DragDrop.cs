using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public float maxLeftPos = 0;
    public float maxRightPos = 10;
    public float maxBottomPos = 0;
    public float maxTopPos = 10;

    Camera cam;

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
        if (transform.position.x < maxLeftPos)
        {
            transform.position = new Vector3(maxLeftPos, transform.position.y, transform.position.z);
        }
        if (transform.position.x > maxRightPos)
        {
            transform.position = new Vector3(maxRightPos, transform.position.y, transform.position.z);
        }
        if (transform.position.y < maxBottomPos)
        {
            transform.position = new Vector3(transform.position.x, maxBottomPos, transform.position.z);
        }
        if (transform.position.y > maxTopPos)
        {
            transform.position = new Vector3(transform.position.x, maxTopPos, transform.position.z);
        }
    }

    private Vector3 GetMousePos()
    {
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    private void Start()
    {
        cam = Camera.main;
    }
}
