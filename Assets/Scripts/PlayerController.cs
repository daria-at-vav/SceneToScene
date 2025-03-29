using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;

    private bool isMoving;
    private Vector2 input;

    private void Update()
    {
        if (!isMoving) 
        { 
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // removes diagonal movement
            if (input.x != 0) input.y = 0;
            
            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }

        
        }

       
        
    }
    IEnumerator Move(Vector3 targetPos)
    {
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
        isMoving = false;
    }
}
