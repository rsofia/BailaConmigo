using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmenuManager : MonoBehaviour
{
    public static bool isDancing = false;
    public static string idAnimation;
    public GameObject[] dancingObj;
    public GameObject[] randomObj;

    public BackAction backAction;

    private void Start()
    {
        //Prender los objetos necesarios para que funcione la escena
        for (int i = 0; i < dancingObj.Length; i++)
            dancingObj[i].SetActive(isDancing);
        for (int i = 0; i < randomObj.Length; i++)
            randomObj[i].SetActive(!isDancing);
    }

    public void GoToSceneWithID(GameObject obj)
    {
        idAnimation = obj.name;

        backAction.GoToScene(2);
    }
}
