using UnityEngine;

public class Screan_OneSprite : MonoBehaviour
{
    float time=0;
    float alpha = 255;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer SR = GetComponent<SpriteRenderer>();
        Stage.CanMove = false;
        this.time += Time.deltaTime;

        if (this.time > 3) {alpha-=1.5f; SR.color = new Color(0, 0, 0, alpha / 255f); }
        if (this.time > 5.5f){ Stage.CanMove = true; Destroy(gameObject);}

        GameObject C = GameObject.Find("Main Camera");
        transform.position = new Vector3(C.transform.position.x+Random.Range(-24f, 24f),Random.Range(-16f,16f), 0);

    }
}
