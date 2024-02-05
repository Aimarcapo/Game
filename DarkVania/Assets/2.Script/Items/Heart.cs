using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heart : MonoBehaviour
{
    public Text heartText;
    public int heartsAmount;
    public static Heart instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHeartText();
    }

    // Update is called once per frame
    
    public void Hearts(int heartAmount)
    {
        heartsAmount += heartAmount;
        UpdateHeartText();
    }
    void UpdateHeartText()
    {
        heartText.text = "x " + heartsAmount.ToString();
    }


}
