using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerControl : MonoBehaviour
{
    public Collections collectScript;

    public void OnScrollbarValueChanged(float value)
    {
        collectScript.UpdateText();
    }
}
