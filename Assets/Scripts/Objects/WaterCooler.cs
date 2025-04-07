using UnityEngine;

public class WaterCooler : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;


    public override void Interact()
    {
        Talk(dialogueText);
        print("interacted");
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }
}
