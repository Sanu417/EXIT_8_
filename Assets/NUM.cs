using UnityEngine;

public class NUM : MonoBehaviour
{
    GameObject BGG;
    public GameObject[] ads;
    bool ResetActive=false;

    GameObject Fake;
    public bool INE;//ç∂ë§Ç…à⁄ìÆÇµÇΩÇ©ÇÃîªíË
    GameObject P;

    GameObject Noise;

    float time=0;
    void Start()
    {
        BGG = GameObject.Find("BGGoal");
        P = GameObject.Find("Player");
        Fake = GameObject.Find("Fake_Toko");
        Noise = GameObject.Find("Noise");
    }

    private void Update()
    {
        if (P.transform.position.x <= transform.position.x+6) INE= true;

        if (Stage.Num == 9 || Stage.Strange == 1) { BGG.SetActive(true); foreach (GameObject ad in ads) ad.SetActive(false); }
        else { BGG.SetActive(false); foreach (GameObject ad in ads) ad.SetActive(true); }


        if (Stage.Strange == 3 && ResetActive) { ads[6].transform.localScale = new Vector3(0.48f, 0.48f, 0.48f); ResetActive = false; }
        if (Stage.Strange == 3){ foreach (GameObject ad in ads) if (ad.transform.localScale.x <= 0.6f) ad.transform.localScale += new Vector3(0.0002f, 0.0002f, 0.0002f);}
        else foreach (GameObject ad in ads) ad.transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);
        if (Stage.Strange == 2) { ads[6].transform.localScale = new Vector3(-0.48f, 0.48f, 0.48f); ResetActive = true; }
        if (!(Stage.Strange == 2 || Stage.Strange == 3)) ads[6].transform.localScale = new Vector3(0.48f, 0.48f, 0.48f);

        if(Stage.Strange == 4 && INE) Fake.SetActive(true); else if(Stage.Strange != 4)Fake.SetActive(false); 

        if(Stage.Strange == 5||(Stage.Strange==6 && INE)) Noise.SetActive(true); else if (!(Stage.Strange == 5||Stage.Strange==6)||!INE) Noise.SetActive(false);

    }
    /*  àŸïœ Stage.Strange
        1 ãUèoå˚
        2 çLçê(îΩì])
        3 çLçê(ãêëÂâª)
        4 ãUTokoéÅ
        5 ÉmÉCÉY(î˜)
        6 ÉmÉCÉY(ïsâ∏)
        7 îºìßñæ
        8 ï\ãLà·îΩ Num3à»è„ÇÃÇ›
        9 çLçê(íuä∑)
     */
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.position.x > transform.position.x)
        {
            transform.Translate(39.4f, 0, 0);
            Stage.Change(true);
        }
        else
        {
            transform.Translate(-39.4f, 0, 0);
            Stage.Change(false);
            INE = false;
        }
    }
    public void ResetPlayer() 
    {
        GameObject P = GameObject.Find("Player"); P.transform.position = new Vector3(transform.position.x - 7, -0.67f, 0);
    }
}
