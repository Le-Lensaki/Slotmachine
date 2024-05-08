using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    static public EffectManager instance;
    public List<GameObject> effects;

    private void Awake()
    {
        EffectManager.instance = this;
        this.LoadEffects();
    }

    protected virtual void LoadEffects()
    {
        this.effects = new List<GameObject>();
        GameObject effect = GameObject.Find("LightTableLeft");
        effects.Add(effect);
        effect.gameObject.SetActive(false);
        GameObject effect2 = GameObject.Find("LightTableRight");
        effects.Add(effect2);
        effect2.gameObject.SetActive(false);
        GameObject effect3 = GameObject.Find("Circle");
        effects.Add(effect3);
        effect3.gameObject.SetActive(false);
        GameObject effect4 = GameObject.Find("RunAround");
        effects.Add(effect4);
        effect4.gameObject.SetActive(false);

        GameObject effect5 = GameObject.Find("LightBtnAuto");
        effects.Add(effect5);
        effect5.gameObject.SetActive(false);

    }

    public virtual void EnbaleVFX(string effectName)
    {
        
        GameObject effect = this.Get(effectName);
        effect.gameObject.SetActive(true);
        
    }

    public virtual void DisableVFX(string effectName)
    {
        GameObject effect = this.Get(effectName);

        ResetAnchor("Anim_Ctrl"+effectName);



        effect.gameObject.SetActive(false);
    }

    void ResetAnchor(string nameObj)
    {
        GameObject anim = GameObject.Find(nameObj);
        if (anim != null)
        {
            anim.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            anim.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        }
    }    
    protected virtual GameObject Get(string effectName)
    {
        foreach (GameObject child in this.effects)
        {
            if (child.name == effectName) return child;
        }
        return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
