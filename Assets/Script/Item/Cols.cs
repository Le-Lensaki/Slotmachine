using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cols : MonoBehaviour
{
    public static Cols instance;

    public List<GameObject> cols;

    protected float timeSpin = 0.2f;

    protected float timer = 0;

    protected int numberRun = 0;
    void Awake()
    {
        Cols.instance = this;

        for (int i = 1; i < 6; i++)
        {
            GameObject col = GameObject.Find("Col"+i);
            cols.Add(col);
        }
    }

    private void FixedUpdate()
    {
        if (Result.instance.isSpin()) timer += Time.deltaTime;

        if (Result.instance.isSpin() && timer >= timeSpin && !Result.instance.boolItemStop[numberRun])
        {
            if(numberRun < 5)
            {
                if (numberRun < 4) Debug.Log("Move tai: " + numberRun);
                timer = 0;
                cols[numberRun].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
                
                if(numberRun < 4) numberRun++;
                
            }
            else
            {
                numberRun = 0;
            }

        }if(!Result.instance.isSpin()) numberRun = 0;

    }

    public virtual void ColsMove()
    {
        AudioManager.instance.PlayMusic("TableSpin");

    }
     

    public virtual void ColsStop(int i)
    {
        
        cols[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        cols[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);


        for (int j = 0; j < 3; j++)
        {

            Slots.instance.slots[i + j * 5].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
        
    }

    
}