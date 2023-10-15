using UnityEngine;

public class EPI : Interactable
{
    [SerializeField] private string epiName;

    // adds the EPI to inventory then destroy itself
    public override void Interact(Interactor interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();

        inventory.AddEpi(epiName);

        Destroy(gameObject);
    }
}
