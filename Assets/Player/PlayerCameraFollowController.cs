using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollowController : MonoBehaviour {

    public float delta = 0.5f;
    public Transform target;
    private Camera _camera;

    private void Awake() {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {

    } 
}
