using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class NonPlayerObject : MonoBehaviour, IInteractable
{

    [SerializeField] private SpriteRenderer interactableIndicator;
    private bool interactable = false;
    private  Transform playerTransform;
    private float interactDistance = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        interactable = WithinInteractDistance();
        if (Keyboard.current.enterKey.wasPressedThisFrame && interactable) 
        {
            Interact();
        }
        if (!interactableIndicator.gameObject.activeSelf && interactable) 
        { 
            // turn on sprite
            interactableIndicator.gameObject.SetActive(true);
        }
        else if (interactableIndicator.gameObject.activeSelf && !interactable)
        {
            // turn off sprite
            interactableIndicator.gameObject.SetActive(false);
        }
    }

    public abstract void Interact();

    public bool WithinInteractDistance() 
    {
        
        if (Vector2.Distance(transform.position, playerTransform.position) < interactDistance)
            return true;
        
        else
            return false;
    }

 /* 
  * private void  OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            interactable = true;
            interactableIndicator.gameObject.SetActive(true);
            print("enter");
        }
        print("enter");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            interactable = false;
            interactableIndicator.gameObject.SetActive(true);
            print("exit");
        }

    }
 */
}
