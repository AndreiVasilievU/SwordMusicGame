using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Animator swordAnimator;
    void Start()
    {
        swordAnimator = GetComponent<Animator>();
        
        var playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += OnInputAction;
    }

    private void OnInputAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        switch (context.action.name)
        {
            case "SwordHitUp" :
                OnSwordButton(1);
                break;
            case "SwordHitRight" :
                OnSwordButton(2);
                break;
            case "SwordHitDown" :
                OnSwordButton(3);
                break;
            case "SwordHitLeft" :
                OnSwordButton(4);
                break;
            case "SwordHitUpRight" :
                OnSwordButton(5);
                break;
            case "SwordHitDownRight" :
                OnSwordButton(8);
                break;
            case "SwordHitDownLeft" :
                OnSwordButton(7);
                break;
            case "SwordHitUpLeft" :
                OnSwordButton(6);
                break;
            case "SwordHitForward" :
                OnSwordButton(9);
                break;
        }
    }

    private void OnSwordButton(int animationNumber)
    {
        swordAnimator.SetInteger("SwordAnimation",animationNumber);
    }
}
