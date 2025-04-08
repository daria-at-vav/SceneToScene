using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class Creep : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    [SerializeField] private PlayerController playerController;

    private Coroutine runAwayCoroutine;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private int interactCount = 0;

    new void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.StopPlayback();
    }

    public override void Interact()
    {
        if (interactCount == 0) 
        {
            animator.SetBool("Interact", true);
            //animator.StartPlayback();
            //runAwayCoroutine = StartCoroutine(RunAway());
            Talk(dialogueText);
        }
        else if (interactCount < 3)
        {
            Talk(dialogueText);

            if (interactCount == 2) {
                animator.SetBool("Runaway", true);
                ExitCreep();
            }
        }
        
        print("interacted");
        interactCount++;        
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }

    private IEnumerator ExitCreep()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

}