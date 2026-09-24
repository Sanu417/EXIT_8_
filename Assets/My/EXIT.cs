using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class EXIT : MonoBehaviour
{
    SpriteRenderer SR;
    GameObject UI;
    GameObject W;
    public bool canintract = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        UI = GameObject.Find("Press Enter to EXIT_0");
        W = GameObject.Find("Global Light 2D");
    }

    // Update is called once per frame
    void Update()
    {
        if (canintract&&Stage.CanMove) 
        {
            UI.SetActive(true);
            if (Keyboard.current.enterKey.wasPressedThisFrame) 
            {
                Stage.CanMove=false;
                StartCoroutine(W.GetComponent<White>().GOAL()); 
            }
        }
        else UI.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision) { canintract = true; }
    private void OnTriggerExit2D(Collider2D collision) { canintract = false; }
}
