using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string prompt;

    public virtual void Interact(Interactor interactor) { }

    public string GetPrompt()
    {
        return prompt;
    }
}
