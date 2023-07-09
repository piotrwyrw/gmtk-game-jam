using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTouchingPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Collider2D playerCollider;
    private Collider2D deathblockCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = player.GetComponent<Collider2D>();
        deathblockCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathblockCollider.IsTouching(playerCollider))
        {
            Debug.Log("player just die already");
            player.GetComponent<CharacterControllerNew>().KillPlayer();
        }
    }
}
