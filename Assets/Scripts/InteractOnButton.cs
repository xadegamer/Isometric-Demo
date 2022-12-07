using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractOnButton : InteractOnTrigger
{
    [Header("InteractOnButton")]
    [SerializeField] private KeyCode button;
    [SerializeField] private UnityEvent OnButtonPress;
    [SerializeField] private int maxButtonInteract;

    private bool canExecuteButtons = false;
    private int currentButtonInteract;

    protected override void ExecuteOnEnter(Collider other)
    {
        base.ExecuteOnEnter(other);
        canExecuteButtons = true;
    }

    protected override void ExecuteOnExit(Collider other)
    {
        base.ExecuteOnExit(other);
        canExecuteButtons = false;
    }

    void Update()
    {
        if (maxButtonInteract > 0 && currentButtonInteract >= maxButtonInteract) return;
            
        if (canExecuteButtons && Input.GetKeyDown(button))
        {
            currentButtonInteract++;
            OnButtonPress.Invoke();
        }
    }
}
