using UnityEngine;
using UnityEngine.SceneManagement;

public class Fridge : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    [SerializeField] private string endScene;

    private int interactCounter = 0;


    public override void Interact()
    {
        if(interactCounter < 5)
        {
            Talk(dialogueText);
        }
        else
        {
            SceneManager.LoadScene(endScene);
        }
        print("interacted");
        interactCounter++;
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }
}
