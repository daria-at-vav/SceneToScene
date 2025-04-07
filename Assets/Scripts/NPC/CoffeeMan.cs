using UnityEngine;

public class CoffeeMan : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    public override void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void Talk(DialogueText text)
    {
        throw new System.NotImplementedException();
    }

    
}
