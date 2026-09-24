using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms;
using System.Collections;
using UnityEngine.SceneManagement;

public class White : MonoBehaviour
{
    public GameObject D;
    Light2D GL;
    void Start() 
    {
        GameObject G = GameObject.Find("Global Light 2D");
        GL = G.GetComponent<Light2D>();
    }
    public IEnumerator GOAL()
    {
        for (int i = 0; i < 400; i++)
        {
            GL.intensity += 0.15f;
            yield return null;
        }
        if (Stage.Num == 9) SceneManager.LoadScene("Goal");
        else {GL.intensity=1; Stage.Dead(); Instantiate(D,new Vector3(0, 0, 0), Quaternion.identity); }
    }
}
