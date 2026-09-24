using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NUMBER : MonoBehaviour
{
    SpriteRenderer SR;
    public Sprite[] SPs;

    public GameObject way;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){SR=GetComponent<SpriteRenderer>();}

    // Update is called once per frame
    void Update()
    {
        if (Stage.Num == -1) SR.sprite = null;
        else if (Stage.Strange == 8) SR.sprite = SPs[Stage.LastNum]; 
        else SR.sprite = SPs[Stage.Num];
    }
}