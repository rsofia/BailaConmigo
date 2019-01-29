using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BackAction))]
public class Menu : MonoBehaviour
{
    public void GoToDance(bool dance)
    {
        SubmenuManager.isDancing = dance;
        GetComponent<BackAction>().GoToScene(1);
    }
}
