using NUnit.Framework.Internal;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static bool CanMove=false;
    public static int Num=-1;//看板の番号
    public static int Strange = 0;//異変のバリエーション。0 なら異変なし
    public static bool TESMODE=false;
    public static int TESStrange=0;

    public static int LBG = 0;
    public static int LastNum = 0;
    public static List<int> SelectedStrange = new List<int>();
 
    public static void Change(bool Gone)
    {
        LastNum = Num;

        if (!Gone) { if (Strange == 0)  Num = 0;  else Num++; }
        if (Gone)  { if (Strange > 0)  Num = 0; else Num++; }
        if (Strange ==-1) Num = 0;


        if (Num == 0) SelectedStrange = new List<int>();
        if (Strange != 0) SelectedStrange.Add(Strange);

        if (TESMODE) { Strange = TESStrange; }
        else
        {
            if (Random.Range(0, 2) == 0) Strange = 0;
            else do { Strange = Random.Range(1, 10); } while (SelectedStrange.Contains(Strange)||(Strange==8&&Num<3));
        }
        if (Num ==9 ) Strange = -1;
        Debug.Log("K"+Num);
        Debug.Log(Strange);
    }
    public static void Dead() 
    {
        Num = 0; SelectedStrange = new List<int>();
        if (TESMODE) { Strange = TESStrange; }
        else
        {
            if (Random.Range(0, 2) == 0) Strange = 0;
            else do { Strange = Random.Range(0, 12); } while (SelectedStrange.Contains(Strange)||Strange==8);           
        }
        GameObject W = GameObject.Find("Way"); W.GetComponent<NUM>().ResetPlayer();
    }
}
