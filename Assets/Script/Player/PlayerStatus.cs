using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    protected PlayerController controller;

    protected static float Cast;

    public Text txtCast;

    private void Awake()
    {
        this.controller = GetComponent<PlayerController>();

        Cast = 900000;

        GameObject CastObj = GameObject.Find("TxtCast");
        if (CastObj != null) this.txtCast = CastObj.GetComponent<Text>();

        txtCast.text = Cast.ToString("N0");
    }

    private void Update()
    {
        if (txtCast != null) this.txtCast.text = Cast.ToString("N0");

        if(Cast <= 0)
        {
            GameObject btnSpin = GameObject.Find("BtnSpin");
            btnSpin.GetComponent<Button>().enabled = false;
            GameObject btnAuto = GameObject.Find("BtnAuto");
            btnAuto.GetComponent<Button>().enabled = false;
        }
    }

    public virtual float getCast()
    {
        return Cast;
    }    

    public virtual void PlusMoney(float Money)
    {
        Cast += Money;
    }

    public virtual void MinusMoney(float Money)
    {
        Cast -= Money;
        if(Cast <= 0) Cast = 0;
    }

    public virtual void NoMoney()
    {
        Debug.Log("Please deposit more money");
    }

}
