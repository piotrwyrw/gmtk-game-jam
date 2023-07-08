using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DynamicCamera : MonoBehaviour {

    private Camera _cam;
    
    private void Start() {
        _cam = GetComponent<Camera>();
    }

    private void FixedUpdate() {
        
    }
}