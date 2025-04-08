using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class DialogueControllerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private float typeSpeed = 10;
    [SerializeField] private PlayerController playerController;
    private float MAX_TYPE_TIME = 0.1f;


    private Queue<string> paragraphs = new Queue<string>();
    private Coroutine typeDialogueCorutine;

    private bool conversationEnded = true;
    private bool isTyping;

    private string para;


    public void DisplayNextParagraph(DialogueText dialogueText) 
    { 
        // if theres nothing in the queue
        if(paragraphs.Count == 0)
        {
            if (conversationEnded) 
            {
                //start a conversation
                StartConvo(dialogueText);
            }
            else if (!conversationEnded && !isTyping)
            {
                //end the conversation
                EndConvo();
                return;
            }
        }

        //if there is something in the queue
        if (!isTyping)
        {
            para = paragraphs.Dequeue();
            typeDialogueCorutine = StartCoroutine(TypeDialogueText(para));
        }
        else
        {
            FinishParagraphEarly();
        }
        

        
    }

    private void StartConvo(DialogueText dialogueText)
    {
        if(playerController != null)
        {
            playerController.Freeze();
        }
        
        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }

        //update name 
        nameText.text = dialogueText.speakerName;

        //add dialogue text to queue
        foreach(string p in dialogueText.paragraphs) 
        { 
            paragraphs.Enqueue(p);
        }
        conversationEnded = false;
    }

    private void EndConvo()
    {
        // clear queue
        if(playerController != null)
        {
            playerController.Unfreeze();
        }
        
        gameObject.SetActive(false);
        conversationEnded = true;

    }

    private IEnumerator TypeDialogueText(string p)
    {
        isTyping = true;

        int maxVisibleChars = 0;

        messageText.text = p;
        messageText.maxVisibleCharacters = maxVisibleChars;

        foreach (char c in p.ToCharArray())
        {

            maxVisibleChars++;
            messageText.maxVisibleCharacters = maxVisibleChars;

            yield return new WaitForSeconds(MAX_TYPE_TIME / typeSpeed);
        }

        isTyping = false;
    }

    private void FinishParagraphEarly() 
    {
        //stop coroutine
        StopCoroutine(typeDialogueCorutine);
        //display rest of text immediately
        messageText.maxVisibleCharacters = para.ToCharArray().Length;
        //update isTyping
        isTyping = false;
    }

}
