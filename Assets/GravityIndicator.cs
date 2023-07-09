using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityIndicator : MonoBehaviour
{
    [SerializeField] bool gravityUpSelected;
    [SerializeField] Color colorGravityDown = new Color(255, 0, 0);
    [SerializeField] Color colorGravityUp = new Color(0, 165, 255);
    [SerializeField] GameObject player;
    private CharacterControllerNew CharacterControllerNew;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        CharacterControllerNew = player.GetComponent<CharacterControllerNew>();
        CharacterControllerNew.onSpacePressed += CharacterControllerNew_onSpacePressed;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gravityUpSelected = false;
        spriteRenderer.color = colorGravityDown;
    }

    private void CharacterControllerNew_onSpacePressed(object sender, System.EventArgs e)
    {
        Debug.Log("Space pressed");
        if (gravityUpSelected)
            gravityUpSelected = false;
        else
            gravityUpSelected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gravityUpSelected)
        {
            spriteRenderer.color = colorGravityUp;
        }
        else
        {
            spriteRenderer.color = colorGravityDown;
        }
    }
}
