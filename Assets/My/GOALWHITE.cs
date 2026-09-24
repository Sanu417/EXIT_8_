using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GOALWHITE : MonoBehaviour
{
    Light2D GL;
    void Awake()
    {
        GL = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GL.intensity >= 2) GL.intensity -= 0.4f;
    }
}
