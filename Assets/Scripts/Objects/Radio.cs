using UnityEngine;

public class Radio : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController; 

    private AudioSource audioSource;
    private bool conversationEnded = false;
    private bool audioOn = true;
    private int interactCounter = 0;

    new void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

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
            if (audioOn)
            {
                audioSource.Pause();
                audioOn = false;
            }
                
            else
            {
                audioSource.Play();
                audioOn = true;
            }


        }

        interactCounter++;
        conversationEnded = interactCounter > 3;


    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }
}
