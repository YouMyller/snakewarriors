using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

    public Button yourButton;

    // Use this for initialization
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

    }

    void OnClick()
    {
        if (name == "Start")
        {
            SceneManager.LoadScene("RealChoosePlayer");
        }

        else if (name == "Credits")
        {
            SceneManager.LoadScene("Credits");
        }

        else if (name == "Exit")
        {
            Application.Quit();
        }

        else if (name == "Back")
        {
            SceneManager.LoadScene("Titles");
        }

        else if (name == "2 players")
        {
            //SceneManager.LoadScene("TwoPlayers");
            SceneManager.LoadScene("scene_2");
        }

        else if (name == "3 players")
        {
            SceneManager.LoadScene("ThreePlayers");
        }

        else if (name == "4 players")
        {
            SceneManager.LoadScene("FourPlayers");
        }
    }
}
