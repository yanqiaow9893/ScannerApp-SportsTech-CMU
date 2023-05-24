using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class Collections : MonoBehaviour
{
    public StringData sd;
    public TMP_Text textObject;
    public static Collections cl;

    // Display the saved lists:
    
    public void Start()
    {
            // load the JSON data from PlayerPrefs
            //string itemListJson = PlayerPrefs.GetString("StringData");

            //sd = JsonUtility.FromJson<StringData>(itemListJson);

            AddResultText(QR.result.Text);
            /*string str = JsonUtility.ToJson(sd, true);
            try
            {
                File.WriteAllText(Application.persistentDataPath + "/save/Saving.txt", str, System.Text.Encoding.UTF8);
            }
            catch
            {
                Debug.LogWarning("Failed to save");
            }
            Debug.Log("Success to save");*/

        
        UpdateText();
    }


    void AddResultText(string val)
    {
        sd.collect_list.Add(val);
        //SaveItemList();
    }

    /*
    void SaveItemList()
    {
        string itemListJson = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("StringData", itemListJson);
    }*/


    public void UpdateText()
    {
        string text = "";
        if (sd == null) return;
        foreach(string str in sd.collect_list)
        {
            text += str + "\n";
        }
        textObject.text = text;

    }

}
