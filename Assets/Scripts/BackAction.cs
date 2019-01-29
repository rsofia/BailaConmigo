using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackAction : MonoBehaviour
{
    public GameObject exitPanel;

    private void Start()
    {
        CloseExitPanel();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
            //salir de la app
            if (currentBuildIndex == 0)
            {
                OpenExitPanel();
            }
            else //ir una escena atras
                GoToScene(currentBuildIndex - 1);

        }
    }


    public void GoToScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void CloseExitPanel()
    {
        if(exitPanel != null)
            exitPanel.SetActive(false);
    }

    private void OpenExitPanel()
    {
        if (exitPanel != null)
            exitPanel.SetActive(true);
    }
}
