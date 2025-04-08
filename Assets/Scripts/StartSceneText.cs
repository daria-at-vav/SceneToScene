using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartSceneText : MonoBehaviour, ITalkable, IInteractable 
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    [SerializeField] private string nextScene;

    private int interactCount = 0;

    public void Interact()
    {
        if(interactCount < 5)
        {
            Talk(dialogueText);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }

        interactCount++;
        
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }

    void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            Interact();
        }
    }
}
