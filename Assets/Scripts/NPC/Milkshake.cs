using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class Milkshake : NonPlayerObject, ITalkable
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
            animator.SetBool("Talking", true);
            Talk(dialogueText);
            print("interacted");
            interactCount++; 

        } else if (interactCount == 5) {
            Talk(dialogueText);
            animator.SetBool("Talking", false);
            print("interacted");
            interactCount = 0;
            
        } else {
            Talk(dialogueText);
            print("interacted");
            interactCount++; 
        }  
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }
}
