using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Risks : Interactable
{
    public override void Interact(Interactor interactor)
    {
        GameManager.instance.score += 1;

        Destroy(gameObject);
    }
}
