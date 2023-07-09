using System;
using UnityEngine;

public class GravityIndicator : MonoBehaviour {
    [SerializeField] bool gravityUpSelected;
    [SerializeField] Color colorGravityDown = new Color(255, 0, 0);
    [SerializeField] Color colorGravityUp = new Color(0, 165, 255);
    [SerializeField] GameObject player;
    private CharacterControllerNew CharacterControllerNew;
    private float factor = 0.0f;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        CharacterControllerNew = player.GetComponent<CharacterControllerNew>();
        CharacterControllerNew.onSpacePressed += CharacterControllerNew_onSpacePressed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colorGravityDown;
    }

    private void CharacterControllerNew_onSpacePressed(object sender, System.EventArgs e) {
        Debug.Log("Space pressed");
        if (gravityUpSelected)
            gravityUpSelected = false;
        else
            gravityUpSelected = true;
    }

    // Update is called once per frame
    void Update() {
        float n = Math.Clamp(CharacterControllerNew.gravity.y,  -9.81f, 9.81f) + 9.81f;
        n /= (9.81f - -9.81f); // Normalize
        n = 1.0f - n; // Invert
        
        float r = (colorGravityDown.r - colorGravityUp.r) * n + colorGravityUp.r;
        float g = (colorGravityDown.g - colorGravityUp.g) * n + colorGravityUp.g;
        float b = (colorGravityDown.b - colorGravityUp.b) * n + colorGravityUp.b;

        Color newColor = new Color(r, g, b);

        spriteRenderer.color = newColor;
    }
}