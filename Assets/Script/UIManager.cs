using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;
    public List<GameObject> uIs;

    private void Awake()
    {
        UIManager.instance = this;
       
    }


    public virtual void EnbaleUI(string uIName)
    {

        GameObject uI = this.Get(uIName);
        uI.gameObject.SetActive(true);

    }

    public virtual GameObject Get(string uIName)
    {
        foreach (GameObject child in this.uIs)
        {
            if (child.name == uIName) return child;
        }
        return null;
    }

   
}
