using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraController : MonoBehaviour
{
    GameObject P;
    bool start = true; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        P = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (start) transform.position = Vector3.Lerp(transform.position,new Vector3(P.transform.position.x,0.15f,-10f), 0.1f);
        if (start&&transform.position == new Vector3(P.transform.position.x, 0.15f, -10)) { start = false; Stage.CanMove = true; gameObject.transform.SetParent(P.transform); }
        //else if (!start) gameObject.transform.SetParent(null);
    }
}
