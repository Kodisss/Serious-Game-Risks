using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
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

    private bool CheckRisksScore()
    {
        if(numberOfRisksIdentified == 5)
        {
            return true;
        }

        return false;
    }

    private void BuildUiScreen()
    {
        if(CheckEPI() && CheckRisksScore())
        {
            winOrLoose.text = "Bravo !";
            epiScore.text = "Tu as �quip� tes EPIs dans le bon ordre !";
            risksScore.text = "Tu as trouv� tout les risques dans la zone !";
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
            timeLeft.text = "Tu as mis " + GameManager.instance.timeTaken + " pour identifier tout les risques";
        }

        if (!CheckEPI())
        {
            epiScore.text = "Tu n'as pas �quip� tes EPIs dans le bon ordre";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        GameManager.instance.isPlaying = true;
        GameManager.instance.score = 0;
        SceneManager.LoadScene("EPIScene");
    }
}