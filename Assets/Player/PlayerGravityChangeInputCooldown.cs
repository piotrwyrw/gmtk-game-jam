using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravityChangeInputCooldown : MonoBehaviour {
    [SerializeField]
    public float Cooldown { get; set; }
    

    private void Awake() {
        this.Cooldown = 0;
    }


    void Update() {
        if(this.Cooldown == 0) return;
        
        this.Cooldown -= Time.deltaTime;

        if (this.Cooldown < 0)
            this.Cooldown = 0;
    }


    public bool IsCooledDown() {
        return this.Cooldown != 0;
    }
}