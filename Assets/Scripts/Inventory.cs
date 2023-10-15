using UnityEngine;
using UnityEngine.SceneManagement;

//Inventory to keep the order of the EPI you picked up
public class Inventory : MonoBehaviour
{
    private string[] epiInventory = new string[7];

    // checks if the inventory is full aka you picked up every EPI
    // then sends the list to the game manager and goes to the next scene
    private void Update()
    {
        if (epiInventory[6] != null)
        {
            GameManager.instance.epiList = epiInventory;
            SceneManager.LoadScene("GameScene");
        }
    }

    public void AddEpi(string epiName)
    {
        epiInventory[CheckInventory()] = epiName;
        //Debug.Log(epiInventory[0] + " " + epiInventory[1] + " " + epiInventory[2] + " " + epiInventory[3] + " " + epiInventory[4] + " " + epiInventory[5]);
    }

    // check the next avaiable spot in Inventory
    private int CheckInventory()
    {
        int res = 0;

        foreach (string epi in epiInventory)
        {
            if (epi == null) return res;
            res++;
        }

        return res;
    }
}
