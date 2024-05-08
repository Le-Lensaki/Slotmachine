using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public static Result instance;

    public List<int> currentRuslt;

    protected bool spin;

    public List<bool> boolItemStop;

    protected float timeStop;

    protected float timer;

    protected int numberColStop = 0;

    private void Awake()
    {
        Result.instance = this;

        spin = false;
        boolItemStop = new List<bool> { false, false, false, false, false };

        this.timeStop = 2f;
        this.timer = 0;
        numberColStop = 0;
    }


    public bool isSpin()
    {
        return spin;
    }
    public void setSpin(bool spin)
    {
        this.spin = spin;
    }


    private void FixedUpdate()
    {
        if (spin) timer += Time.deltaTime;

        if (spin && timer > timeStop)
        {
            if (numberColStop < 5)
            {
                if (Slots.instance.lastFrame[numberColStop] == numberColStop + 10)
                {
                    
                    Debug.Log("Stop tai: " + numberColStop);
                    timer = 0;
                    Cols.instance.ColsStop(numberColStop);
                    boolItemStop[numberColStop] = true;
                    numberColStop++;
                }   
                
            }
            else
            {
                numberColStop = 0;   
            }

        }
        if (!spin)
        {
            numberColStop = 0;
            timer = 0;
        }
    }


    public virtual void CheckStop()
    {
        if(!boolItemStop.Contains(false))
        {
            spin = false;
            GameManager.instance.setTimer(0);
            boolItemStop = new List<bool> { false, false, false, false, false };
            GameObject btnSpin = GameObject.Find("BtnSpin");
            btnSpin.GetComponent<Button>().enabled = true;
            

            if (!GameManager.instance.isAutoSpin())
            {
                EffectManager.instance.DisableVFX("RunAround");
                EffectManager.instance.DisableVFX("Circle");
            }

            AudioManager.instance.StopMusic();
            GameManager.instance.CheckWin();
        }    
        
    }
}
