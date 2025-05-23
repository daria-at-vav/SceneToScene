using System.Collections;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public const float MOVEMENT_SPEED = 5f;
    // tilemap that things that cannot be walked on/under are placed on
    public Tilemap solidTilemap;
    // offset because the rounding in isMovable tile messes up the y position
    public Vector3Int add;

    private bool isMoving;
    private bool isFrozen = false;
    private Vector2 input;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isMoving) 
        { 
            // gets current input
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // removes diagonal movement
            if (input.x != 0) input.y = 0;
            
            // if there is input and Frosk isnt frozen
            if (input != Vector2.zero && !isFrozen)
            {
                // tells the animator which way the player is moving
                animator.SetFloat("MoveX", input.x);
                animator.SetFloat("MoveY", input.y);

                // sets target position to players current positon
                var targetPos = transform.position;

                // sets target position to one tile up right left or down from current position
                targetPos.x += input.x;
                targetPos.y += input.y;

                // if the tile the player wants to walk on is able to be walked on then move the player to that tile
                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }

        
        }

        animator.SetBool("IsMoving", isMoving);
        
    }

    // this is what actually moves the player, it takes a target position and smoothly moves the player to that point
    IEnumerator Move(Vector3 targetPos)
    {
        // player is currently moving between two tiles
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) // if target position and transform position are different enough
        { 
            //move position closer to target position
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            // go to next frame
            yield return null;
        }
        // if theyre close enough just snap player pos to target pos
        transform.position = targetPos;
        // player is no longer moving
        isMoving = false;
    }

    private bool IsWalkable(Vector3 target)
    {
        // if the target tile position exists in the solid tilemap the tile is not walkable
        if (solidTilemap.GetTile(Vector3Int.FloorToInt(target) + add) != null)
        {
            print("BONK!");
            return false;
        }

        // else tile is walkable
        else
            return true;
    }

    public void Freeze() 
    {
        movementSpeed = 0;
        isFrozen = true;
    }

    public void Unfreeze() 
    {
        movementSpeed = MOVEMENT_SPEED;
        isFrozen = false;
    }
}
