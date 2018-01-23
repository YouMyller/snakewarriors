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
            SceneManager.LoadScene("ChoosePlayer");
        }

        else if (name == "Credits")
        {
            SceneManager.LoadScene("Credits");
        }

        else if (name == "Exit")
        {
            print("There is no escape!");
        }

        else if (name == "Back")
        {
            SceneManager.LoadScene("Titles");
        }

        else if (name == "lvl1")
        {
            SceneManager.LoadScene("level_1");
        }

        else if (name == "lvl2")
        {
            SceneManager.LoadScene("level_2");
        }
    }
}
