using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class DeadPlantScript : NonPlayerObject
{

    [SerializeField] private PlayerController playerController;
    private Animator animator;

    new void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        animator.StopPlayback();
    }

    public override void Interact()
    {
        animator.SetBool("Dead", true);
        print("interacted");
    }
}
