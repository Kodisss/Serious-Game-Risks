using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    private string[] epiInventory = new string[7];

    private void Update()
    {
        if (epiInventory[6] != null) SceneManager.LoadScene("GameScene");
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
