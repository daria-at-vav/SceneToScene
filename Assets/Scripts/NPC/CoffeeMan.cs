using UnityEngine;

public class CoffeeMan : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    public override void Interact()
    {
        Talk(dialogueText);
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }

    
}
