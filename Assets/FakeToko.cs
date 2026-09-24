using UnityEngine;

public class FakeToko : MonoBehaviour
{
    public Sprite[] TokoLooks;
    public Sprite[] TokoLooks2;
    float time=0;
    float StandTime = 0;
    int T = 0;
    bool TR = true;

    public AudioClip FakeScream;
    public GameObject TokoScrean;
    int alpha = 88;
    bool up = true;
    SpriteRenderer SR;
    private void Awake()
    {
        SR=GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (up) { alpha += 1; if (alpha > 215) up = false; }
        else { alpha -= 1; if (alpha < 88) up = true; }

        SR.color = new Color(1,1,1,alpha/255f);

        StandTime += Time.deltaTime;
        time += Time.deltaTime;
        if (StandTime > 5)
        {
            if (TR) { T = 0; TR = false; }
            if (time > 0.12f)
            {
                if (T >= TokoLooks2.Length) { T = 0; StandTime = 0; }
                SR.sprite = TokoLooks2[T++];
                //if (T==)
                if (T == 5 || T == 9) time = -0.3f;
                else time = 0;
            }
        }
        else
        {
            TR = true;
            if (time > 0.25f)
            {
                if (T >= TokoLooks.Length) T = 0;
                SR.sprite = TokoLooks[T++];
                if (T == 1) time=-0.15f; else time = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(TokoScrean, new Vector3(0,0,0), Quaternion.identity);
        collision.GetComponent<AudioSource>().generator=FakeScream;
        collision.GetComponent<AudioSource>().pitch = 1;
        collision.GetComponent<AudioSource>().Play();
        Stage.Dead();
    }
}
