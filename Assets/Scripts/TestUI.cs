using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    public int clicked = 0;
    public Text Text;

    public void Awake()
    {
        Text.text = clicked.ToString();
    }

    public void ButtonClicked()
    {
        clicked++;
        Text.text = clicked.ToString();
    }
}
