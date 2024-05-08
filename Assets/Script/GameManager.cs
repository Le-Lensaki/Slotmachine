using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;

    protected bool autoSpin;

    protected float timer;

    // Start is called before the first frame update
    void Start()
    {
        autoSpin = false;
        GameManager.instance = this;
        this.timer = 0f;
    }

    public virtual bool isAutoSpin()
    {
        return autoSpin;
    }

    public virtual void setAutoSpin(bool spin)
    {
        autoSpin= spin;
    }

    public virtual float getTimer()
    {
        return timer;
    }

    public virtual void setTimer(float time)
    {
        timer = time;
    }



    public virtual void Spin()
    {
        Result.instance.setSpin(true);

        GameObject uiWin = UIManager.instance.Get("ScreenWin");
        if (uiWin != null) uiWin.SetActive(false);

        AudioManager.instance.PlaySFX("Spin");

        Item.instance.CreateCurrentItems();

        Slots.instance.SetPicture();

        Cols.instance.ColsMove();

        Bet.instance.setCurrentBet();

        PlayerController.instance.status.MinusMoney(Bet.instance.getCurrentBet());

        JackpotController.instance.PlusTotalJackpot(Bet.instance.getCurrentBet());

        GameObject btnSpin = GameObject.Find("BtnSpin");
        btnSpin.GetComponent<Button>().enabled = false;

        EffectManager.instance.EnbaleVFX("Circle");
        
        EffectManager.instance.EnbaleVFX("RunAround");
        
        
    }

    public virtual void CheckWin()
    {
        if (Item.instance.checkXien() > -1)
        {
            float moneyWin = Bet.instance.getCurrentBet() * Item.instance.checkXien();
            
            PlayerController.instance.status.PlusMoney(moneyWin);
            JackpotController.instance.MinusTotalJackpot(moneyWin);
            Bet.instance.resSetCurrentBet();

            if (moneyWin > 0)
            {
                GameObject uiWin = UIManager.instance.Get("ScreenWin");
                uiWin.SetActive(true);
                Text txtWin = GameObject.Find("TxtWin").GetComponent<Text>();
                txtWin.text = moneyWin.ToString("N0");
                AudioManager.instance.PlaySFX("Win");
                if(autoSpin) Auto();


            }
        }
        else if(Item.instance.checkXien() == -1)
        {
            PlayerController.instance.status.PlusMoney(JackpotController.instance.getTotalJackPot());

            GameObject uiWin = UIManager.instance.Get("ScreenWin");
            uiWin.SetActive(true);
            Text txtWin = GameObject.Find("TxtWin").GetComponent<Text>();
            txtWin.text = JackpotController.instance.getTotalJackPot().ToString("N0");
            AudioManager.instance.PlaySFX("Win");
            if (autoSpin) Auto();


            JackpotController.instance.BreakJackpot();
            Bet.instance.resSetCurrentBet();
        }
    }    

    private void FixedUpdate()
    {
        if(Result.instance.isSpin())
            Slots.instance.RefSlot();

        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            if (!Result.instance.isSpin() && autoSpin)
            {
                Spin();
            }
            
        }
        
        if (Input.touchCount > 0)
        {
            GameObject uiWin = UIManager.instance.Get("ScreenWin");
            if (uiWin != null) uiWin.SetActive(false); 
        }
            
    }

    public virtual void PlusBet()
    {
        Bet.instance.PlusBet();
        AudioManager.instance.PlaySFX("Bet");
    }

    public virtual void MinusBet()
    {
        Bet.instance.MinusBet();
        AudioManager.instance.PlaySFX("Bet");
    }


    public virtual void MaxBet()
    {
        Bet.instance.AllIn(PlayerController.instance.status.getCast());
        AudioManager.instance.PlaySFX("Bet");
    }
    
    public virtual void Auto()
    {
        AudioManager.instance.PlaySFX("Bet");
        if (autoSpin)
        {
            autoSpin = false;
            EffectManager.instance.DisableVFX("LightBtnAuto");
            GameObject btnAuto = UIManager.instance.Get("BtnAuto");
            if(btnAuto != null)
            {
                btnAuto.GetComponent<UIEffect>().enabled = false;
                btnAuto.GetComponent<UIShadow>().enabled = false;
            }
            
        }    
            
        else
        {
            autoSpin = true;
            EffectManager.instance.EnbaleVFX("LightBtnAuto");
            GameObject btnAuto = UIManager.instance.Get("BtnAuto");
            if (btnAuto != null)
            {
                btnAuto.GetComponent<UIEffect>().enabled = true;
                btnAuto.GetComponent<UIShadow>().enabled = true;
            }
        }    
            
    }

}
