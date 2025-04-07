using UnityEngine;
using UnityEngine.UI;

public class Floorplan : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    [SerializeField] private Image detailedMap;

    private bool conversationEnded = false;
    private bool mapVisible = false;
    private int interactCounter = 0;

    public override void Interact()
    {
        print(interactCounter);
        print(conversationEnded);
        if (!conversationEnded)
        {
            Talk(dialogueText);
            print("interacted");
        }
        else
        {
            detailedMap.gameObject.SetActive(!mapVisible);
            mapVisible = !mapVisible;
        }

        interactCounter++;
        conversationEnded = interactCounter > 3;
        
        
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }

}
