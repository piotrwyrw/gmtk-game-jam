using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerNew : MonoBehaviour {

    private InputActionManager _inputActionManager;
    
    private void Awake() {
        this._inputActionManager = new InputActionManager();
    }

    private void OnEnable() {
        this._inputActionManager.Enable();
    }

    private void OnDisable() {
        this._inputActionManager.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
