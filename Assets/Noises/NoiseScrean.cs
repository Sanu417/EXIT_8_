using UnityEngine;

public class NoiseScrean : MonoBehaviour
{
    public Sprite[] Noises;
    int N=0;
    int alpha;
    SpriteRenderer SR;
    AudioSource AD;
    public AudioClip NoiseScream;
    public GameObject Black;
    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        AD = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite=Noises[N++];
        if (N >= Noises.Length) N = 0;

        GameObject Way = GameObject.Find("Way");
        GameObject P = GameObject.Find("Player");

        if (Stage.Strange == 5) { SR.color = new Color(1, 1, 1, 6 / 255f); AD.volume = 0f; }


        float s = Way.transform.position.x+14 - P.transform.position.x;

        if (Stage.Strange == 6) 
        { 
            SR.color = new Color(1, 1, 1, (255 - s * 35) / 255f);AD.volume = (255 - s * 22) / 305f;
            if (P.transform.position.x > Way.transform.position.x + 16)
            {
                AD.volume = 0;
                Instantiate(Black, new Vector3(0, 0, 0), Quaternion.identity);
                //P.GetComponent<AudioSource>().generator = NoiseScream;
                //P.GetComponent<AudioSource>().pitch = 0.95f;
                //P.GetComponent<AudioSource>().Play();
                Stage.Dead();
            }
        }
    }
}
