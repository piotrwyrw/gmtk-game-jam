using UnityEngine;

public class IsTouchingPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Collider2D playerCollider;
    private Collider2D deathblockCollider;
    private CharacterControllerNew _characterControllerNew;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerCollider = player.GetComponent<Collider2D>();
        deathblockCollider = GetComponent<Collider2D>();
        _characterControllerNew = player.GetComponent<CharacterControllerNew>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathblockCollider.IsTouching(playerCollider))
        {
            _characterControllerNew.KillPlayer();
        }
    }
}
