using System.Collections;
using UnityEditor.Search;
using UnityEngine;

public class Skelly : NonPlayerObject, ITalkable
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    [SerializeField] private Sprite fallenSprite;
    

    private SpriteRenderer spriteRenderer;

    new void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public override void Interact()
    {
        Talk(dialogueText);
        spriteRenderer.sprite = fallenSprite;
        print("interacted");
        
    }

    public void Talk(DialogueText text)
    {
        dialogueController.DisplayNextParagraph(text);
    }




}
