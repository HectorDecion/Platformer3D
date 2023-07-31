using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
        public void toTutorial()
        {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(00);
    }
}
