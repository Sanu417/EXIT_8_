using UnityEngine;

public class ad9 : MonoBehaviour
{
    SpriteRenderer SR;
    public Sprite True;
    public Sprite False;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Stage.Strange ==9) SR.sprite = True;
        else SR.sprite = False;
    }
}
