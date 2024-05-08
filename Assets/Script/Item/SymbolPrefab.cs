using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolPrefab : MonoBehaviour
{
    public static SymbolPrefab instance;

    public List<Sprite> symbolList;
    void Awake()
    {
        SymbolPrefab.instance = this;
    }


}
