using UnityEngine;
using UnityEngine.UI;

public class GovFolder : NonPlayerObject, ITalkable
{

    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    [SerializeField] private Image govPapers;

    private bool conversationEnded = false;
    private bool papersVisible = false;
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
            govPapers.gameObject.SetActive(!papersVisible);
            papersVisible = !papersVisible;
        }

        interactCounter++;
        conversationEnded = interactCounter > 3;
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }

}
