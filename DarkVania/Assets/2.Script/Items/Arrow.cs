using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Arrow : MonoBehaviour
{
    public Text arrowText;
    public int arrowsAmount;
    public static Arrow instance;
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
        UpdateArrowText();
    }

    // Update is called once per frame
    
    public void Arrows(int arrowAmount)
    {
        arrowsAmount += arrowAmount;
        UpdateArrowText();
    }
    void UpdateArrowText()
    {
        arrowText.text = "x " + arrowsAmount.ToString();
    }


}
