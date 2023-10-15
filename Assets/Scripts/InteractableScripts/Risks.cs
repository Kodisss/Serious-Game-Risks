using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class that defines how risks are dealt with when interacted with
public class Risks : Interactable
{
    public override void Interact(Interactor interactor)
    {
        GameManager.instance.score += 1;

        Destroy(gameObject);
    }
}
