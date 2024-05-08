using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JackpotController : MonoBehaviour
{
    public static JackpotController instance;

    protected static float totalJackPot = 900000;

    public Text txtTotal;

    private void Awake()
    {
        JackpotController.instance = this;


        GameObject txtJackbot = GameObject.Find("TxtJackpot");
        if (txtJackbot != null) this.txtTotal = txtJackbot.GetComponent<Text>();

        txtTotal.text = totalJackPot.ToString("N0");
    }

    public virtual float getTotalJackPot()
    {
        return totalJackPot;
    }    

    public virtual void PlusTotalJackpot(float money)
    {
        if (money > 0) totalJackPot += money; 
    }

    public virtual void MinusTotalJackpot(float money)
    {
        if(money > 0) 
            totalJackPot -= money;
    }

    public virtual void BreakJackpot()
    {
        totalJackPot = 90000;
    }

    private void Update()
    {
        if (txtTotal != null) this.txtTotal.text = totalJackPot.ToString("N0");
    }

}
