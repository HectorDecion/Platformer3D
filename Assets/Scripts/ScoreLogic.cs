using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLogic : MonoBehaviour
{
    public TMP_Text starText;

    private void Start()
    {
        LoadData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetString("Score: ", starText.text);
    }

    public void LoadData()
    {
        PlayerPrefs.GetString("");
    }
//    public void DeleteData()
 //   {
 //       PlayerPrefs.DeleteKey("Input");
 //       PlayerPrefs.DeleteAll();
 //   }
}
