using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class GuyTM : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    private Animator animator;
    private int interactCount = 0;

    new void Start() {
        base.Start();
        animator = GetComponent<Animator>();
        animator.StopPlayback();
    }

    public override void Interact() {
        
        if (interactCount == 0) {
            Talk(dialogueText);
        } else if (interactCount == 1) {
            animator.SetBool("bored", true);
            Talk(dialogueText);
        } else if (interactCount == 2) {
            animator.SetBool("bored", false);
            Talk(dialogueText);
        } else if (interactCount == 4){
            animator.SetBool("bored", true);
            Talk(dialogueText);
        } else if (interactCount == 5){
            animator.SetBool("bored", false);
            Talk(dialogueText);
        } else {
            Talk(dialogueText);
        }
        
        print("interacted");
        interactCount++;  
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }
}
