using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Tilemap wallTilemap;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float idleThreshold = 0.1f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        UpdateAnimations();
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed;

        HandleWallCollision();
    }

    void UpdateAnimations()
    {
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);

        spriteRenderer.flipX = movement.x > 0;

        if (movement.sqrMagnitude < idleThreshold * idleThreshold)
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    void HandleWallCollision()
    {
        // Get the player's current position in the grid
        Vector3Int cellPosition = wallTilemap.WorldToCell(transform.position);

        // Check if the cell at the player's position in the WallLayer is not null (indicating a wall)
        if (wallTilemap.GetTile(cellPosition) != null)
        {
            // Player is colliding with a wall, stop the movement
            rb.velocity = Vector2.zero;

            // Move the player slightly away from the wall
            Vector3 hitNormal = wallTilemap.GetTransformMatrix(cellPosition).MultiplyVector(Vector3.up);
            transform.position += hitNormal * 0.1f; // Adjust the multiplier as needed
        }
    }
}
