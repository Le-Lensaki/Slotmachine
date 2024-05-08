using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static Item instance;

    public List<int> currentItems;

    protected int max_Items = 8;

    private void Awake()
    {
        Item.instance = this;
    }

    public virtual void CreateCurrentItems()
    {
        currentItems.Clear();
        for (int i = 0; i < 15; i++)
        {
            currentItems.Add(GetRandom());
        }
    }

    public virtual int GetRandom()
    {
        return Random.Range(0, max_Items - 1);
    }


    //Check Win Old dont use
    #region CheckWinOld
    //public virtual int CheckItem()
    //{
    //    int percent = 0;



    //    if (currentItems[0] == currentItems[1] && currentItems[0] == currentItems[2] && currentItems[0] == currentItems[3] && currentItems[0] == currentItems[4])
    //    {
    //        for (int i = 0; i < 5; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 3;
    //    }

    //    if (currentItems[5] == currentItems[6] && currentItems[5] == currentItems[7] && currentItems[5] == currentItems[8] && currentItems[5] == currentItems[9])
    //    {
    //        for (int i = 5; i < 10; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent = -1;
    //    }
    //    if (currentItems[10] == currentItems[11] && currentItems[10] == currentItems[12] && currentItems[10] == currentItems[13] && currentItems[10] == currentItems[14])
    //    {
    //        for (int i = 10; i < 15; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 3;
    //    }

    //    if (currentItems[0] == currentItems[1] && currentItems[0] == currentItems[2] && currentItems[0] == currentItems[3])
    //    {
    //        for (int i = 0; i < 4; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 2;
    //    }
    //    if (currentItems[5] == currentItems[6] && currentItems[5] == currentItems[7] && currentItems[5] == currentItems[8])
    //    {
    //        for (int i = 5; i < 9; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 2;
    //    }
    //    if (currentItems[10] == currentItems[11] && currentItems[10] == currentItems[12] && currentItems[10] == currentItems[13])
    //    {
    //        for (int i = 10; i < 14; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 2;
    //    }

    //    if (currentItems[0] == currentItems[1] && currentItems[0] == currentItems[2])
    //    {
    //        for (int i = 0; i < 3; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 1;
    //    }
    //    if (currentItems[5] == currentItems[6] && currentItems[5] == currentItems[7])
    //    {
    //        for (int i = 5; i < 8; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 1;
    //    }
    //    if (currentItems[10] == currentItems[11] && currentItems[10] == currentItems[12])
    //    {
    //        for (int i = 10; i < 13; i++)
    //        {
    //            Slots.instance.HighLightResult(i);
    //        }
    //        return percent += 1;
    //    }

    //    return percent;
    //}
    #endregion

    public virtual List<int> checkList(int number)
    {
        List<int> vitri = new List<int>();  

        for (int i = 0; i < 15; i++)
        {
            if(currentItems[i] == number) vitri.Add(i);
        }

        return vitri;
    }

    public virtual int checkX(List<int> row, int checkCol)
    {
        int x = 1;
        int mulCol2 = 0;
        int mulCol3 = 0;
        int mulCol4 = 0;
        int mulCol5 = 0;


        if (checkCol >= 2)
        {   
            if(row.Contains(1)) mulCol2 += 1;
            if (row.Contains(6)) mulCol2 += 1;
            if (row.Contains(11)) mulCol2 += 1;
        }

        if (checkCol >= 3)
        {
            if (row.Contains(2)) mulCol3 += 1;
            if (row.Contains(7)) mulCol3 += 1;
            if (row.Contains(12)) mulCol3 += 1;
        }

        if (checkCol >= 4)
        {
            if (row.Contains(3)) mulCol4 += 1;
            if (row.Contains(8)) mulCol4 += 1;
            if (row.Contains(13)) mulCol4 += 1;
        }
        else
        {
            return x = mulCol2 * mulCol3;
        }

        if (checkCol >= 5)
        {
            if (row.Contains(4)) mulCol5 += 1;
            if (row.Contains(9)) mulCol5 += 1;
            if (row.Contains(14)) mulCol5 += 1;
        }
        else
        {
            return x = mulCol2 * mulCol3 * mulCol4;
        }

        return x = mulCol2 * mulCol3 * mulCol4 * mulCol5; 
    }    


    
    public virtual float checkXien()
    {
        float percent = 0;

        if (currentItems[5] == 4 && currentItems[5] == currentItems[6] && currentItems[5] == currentItems[7] && currentItems[5] == currentItems[8] && currentItems[5] == currentItems[9])
        {
            for (int i = 5; i < 10; i++)
            {
                Slots.instance.HighLightResult(i);
            }
            return percent = -1;
        }



        List<int> row1 = checkList(currentItems[0]);
        List<int> row2 = checkList(currentItems[5]);
        List<int> row3 = checkList(currentItems[10]);

        if(row1.Contains(1) || row1.Contains(6) || row1.Contains(11))
        {
            if (row1.Contains(2) || row1.Contains(7) || row1.Contains(12))
            {
                if (row1.Contains(3) || row1.Contains(8) || row1.Contains(13))
                {
                    if (row1.Contains(4) || row1.Contains(9) || row1.Contains(14))
                    {
                        percent += 3f*checkX(row1, 5);
                        foreach (var item in row1)
                        {
                            Slots.instance.HighLightResult(item);
                        }
                    }
                    else
                    {
                        percent += 1.2f*checkX(row1, 4);
                        foreach (var item in row1)
                        {
                            if (item == 4 || item == 9 || item == 14) continue;
                            Slots.instance.HighLightResult(item);
                        }
                    }
                }
                else
                {
                    percent += 0.2f* checkX(row1,3);
                    foreach (var item in row1)
                    {
                        if (item == 3 || item == 8 || item == 13 || item == 4 || item == 9 || item == 14) continue;
                        Slots.instance.HighLightResult(item);
                    }
                }
            }    
        }

        if (row2.Contains(1) || row2.Contains(6) || row2.Contains(11))
        {
            if (row2.Contains(2) || row2.Contains(7) || row2.Contains(12))
            {
                if (row2.Contains(3) || row2.Contains(8) || row2.Contains(13))
                {
                    if (row2.Contains(4) || row2.Contains(9) || row2.Contains(14))
                    {
                        percent += 3f * checkX(row1, 5);
                        foreach (var item in row2)
                        {
                            Slots.instance.HighLightResult(item);
                        }
                    }
                    else
                    {
                        percent += 1.2f * checkX(row2, 4);
                        foreach (var item in row2)
                        {
                            if (item == 4 || item == 9 || item == 14) continue;
                            Slots.instance.HighLightResult(item);
                        }
                    }
                }
                else
                {
                    percent += 0.2f * checkX(row2, 3);
                    foreach (var item in row2)
                    {
                        if (item == 3 || item == 8 || item == 13 || item == 4 || item == 9 || item == 14) continue;
                        Slots.instance.HighLightResult(item);
                    }
                }
            }
        }

        if (row3.Contains(1) || row3.Contains(6) || row3.Contains(11))
        {
            if (row3.Contains(2) || row3.Contains(7) || row3.Contains(12))
            {
                if (row3.Contains(3) || row3.Contains(8) || row3.Contains(13))
                {
                    if (row3.Contains(4) || row3.Contains(9) || row3.Contains(14))
                    {
                        percent += 3f * checkX(row3, 5);
                        foreach (var item in row3)
                        {
                            Slots.instance.HighLightResult(item);
                        }
                    }
                    else
                    {
                        percent += 1.2f * checkX(row3, 4);
                        foreach (var item in row3)
                        {
                            if (item == 4 || item == 9 || item == 14) continue;
                            Slots.instance.HighLightResult(item);
                        }
                    }
                }
                else
                {
                    percent += 0.2f * checkX(row3, 3);
                    foreach (var item in row3)
                    {
                        if (item == 3 || item == 8 || item == 13 || item == 4 || item == 9 || item == 14) continue;
                        Slots.instance.HighLightResult(item);
                    }
                }
            }
        }

        return percent;

    }
}
