using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadToFirstLvl : MonoBehaviour
{
    public void toFirstlvl()
    {
        SceneManager.LoadScene(01);
    }
}
