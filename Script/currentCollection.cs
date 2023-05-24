using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class currentCollection : MonoBehaviour
{
    public TextMeshProUGUI dispaly_qrName;
    public static string myString;

    public void Awake()
    {
        dispaly_qrName.text = QR.result.Text;
        Debug.Log("QR reading done");
        myString = dispaly_qrName.text;
    }
}
