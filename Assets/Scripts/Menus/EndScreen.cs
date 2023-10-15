using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MainMenu
{
    [SerializeField] TMP_Text winOrLoose;
    [SerializeField] TMP_Text timeLeft;
    [SerializeField] TMP_Text epiScore;
    [SerializeField] TMP_Text risksScore;
    private int numberOfRisksIdentified;

    private string[] epi = new string[]
                        {
                            "Bleu",
                            "Casque",
                            "Chaussures",
                            "Lunettes",
                            "Gants",
                            "Bouchons",
                            "Lumi�re"
                        };

    private void Start()
    {
        Cursor.visible = true;
        numberOfRisksIdentified = GameManager.instance.score;
        BuildUiScreen();
    }

    private bool CheckEPI()
    {
        int epiScore = 0;

        for (int i = 0; i < epi.Length; i++)
        {
            if (epi[i] == GameManager.instance.epiList[i]) epiScore++;
        }

        if (epiScore == 7)
        {
            return true;
        }

        return false;
    }

    private void BuildUiScreen()
    {
        if(CheckEPI() && numberOfRisksIdentified == 5)
        {
            winOrLoose.text = "Bravo !";
        }
        else
        {
            winOrLoose.text = "Essaye encore !";
        }

        if(numberOfRisksIdentified != 5)
        {
            risksScore.text = "Tu as trouv� " + numberOfRisksIdentified + " des 5 risques dans la zone";
            timeLeft.text = "Temps Ecoul� !";
        }
        else
        {
            timeLeft.text = "Tu as mis " + GameManager.instance.timeTaken.ToString("0") + "s pour identifier tous les risques";
            risksScore.text = "Tu as trouv� tous les risques dans la zone !";
        }

        if (CheckEPI())
        {
            epiScore.text = "Tu as �quip� tes EPIs dans le bon ordre !";
        }
        else
        {
            epiScore.text = "Tu n'as pas �quip� tes EPIs dans le bon ordre";
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}