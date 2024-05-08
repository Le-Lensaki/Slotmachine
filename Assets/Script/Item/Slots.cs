using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public static Slots instance;

    public List<GameObject> slots;

    public List<int> lastFrame;

    public GameObject finalPos;
    public GameObject spawnPos;

    void Awake()
    {
        Slots.instance = this;

        
        for (int i = 0; i < 15; i++)
        {     
            slots.Add(GameObject.Find(i.ToString()));
        }

        for (int i = 10; i < 15; i++)
        {
            lastFrame.Add(i);
        }
        this.finalPos = GameObject.Find("FinalPos");
        this.spawnPos = GameObject.Find("SpawnPos");

    }

    private void Start()
    {
        DisableHighLightResult();
        Slots.instance.finalPos.transform.position = new Vector3(Slots.instance.slots[12].transform.position.x, Slots.instance.slots[12].transform.position.y - (Slots.instance.slots[7].transform.position.y - Slots.instance.slots[12].transform.position.y), 0);
    }

    public virtual void SetPicture()
    {

        for (int i = 0; i < 15; i++)
        {
            slots[i].GetComponent<Image>().sprite = SymbolPrefab.instance.symbolList[Item.instance.currentItems[i]];
        }
        DisableHighLightResult();
    }

    public virtual void HighLightResult(int i)
    {
        slots[i].GetComponent<UIShiny>().enabled = true;
    }

    public virtual void DisableHighLightResult()
    {
        for (int i = 0; i < 15; i++)
        {
            slots[i].GetComponent<UIShiny>().enabled = false;
        }
        
    }

    public virtual void ChangePicture(int lastFrame)
    {
        Item.instance.currentItems[lastFrame] = Item.instance.GetRandom();
        slots[lastFrame].GetComponent<Image>().sprite = SymbolPrefab.instance.symbolList[Item.instance.currentItems[lastFrame]];
    }

    public virtual void RefSlot()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject refSlot = Cols.instance.cols[i].transform.Find(lastFrame[i].ToString()).gameObject;
            if (refSlot != null)
            {
                if (refSlot.transform.position.y < finalPos.transform.position.y)
                {

                    ChangePicture(lastFrame[i]);
                    lastFrame[i] -= 5;
                    if (lastFrame[i] < 0)
                    {
                        lastFrame[i] += 15;
                    }
                    refSlot.transform.position = new Vector2(refSlot.transform.position.x, spawnPos.transform.position.y);
                    
                }
            }
            Result.instance.CheckStop();

        }
    }



}
