using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bet : MonoBehaviour
{
    //protected PlayerController controller;

    public static Bet instance;

    private static float moneyBet;

    private static float currentBet;

    public Text txtBet;

    private void Awake()
    {
        Bet.instance = this;
        currentBet = 0;

        moneyBet = 2000;

        GameObject txtBetObj = GameObject.Find("TxtBet");
        if (txtBetObj != null) this.txtBet = txtBetObj.GetComponent<Text>();

        txtBet.text = moneyBet.ToString("N0");
    }

    public virtual float getCurrentBet()
    {
        return currentBet;
    }    
 
    public virtual void setCurrentBet()
    {
        currentBet = moneyBet;
    }

    public virtual void resSetCurrentBet()
    {
        currentBet = 0;
    }

    public virtual float getBet()
    {
        return moneyBet;
    }
    public virtual void PlusBet()
    {
        moneyBet += 1000;
        if(PlayerController.instance.status.getCast() < moneyBet) moneyBet = PlayerController.instance.status.getCast();
    }

    public virtual void MinusBet()
    {
        moneyBet -= 1000;
        if(moneyBet < 0) moneyBet = 0;
    }

    public virtual void AllIn(float money)
    {
        moneyBet = money;
    }    

    private void Update()
    {
        if(txtBet != null && moneyBet > 0)  this.txtBet.text = moneyBet.ToString("N0");
    }





}
