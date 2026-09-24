
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool isMoving;
    public float speed;
    public bool CanInteract;
    public float IdolTime;
    public float time=0f;//アニメーションによる画像の切り替えのための時間計測
    bool ICWFirst=false;
    bool ICWFirsted=false;

    public bool TESTMODE=false;//trueの時にStageを更新するとTESStrの番号の異変が発生する
    public int TESStr=0;

    SpriteRenderer SR;
    public Sprite[] SPI;//Sprite Idol
    int SPICount=0;
    public Sprite[] SPIA;//Sprite Idol Action
    public int SPIACount=0;
    public Sprite[] SPW;//Sprite Walk
    int SPWCount=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.shiftKey.isPressed) speed = 0.3f;
        else speed = 0.1f;
        isMoving = true;

        if ((Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed) && Stage.CanMove) { transform.Translate(speed, 0, 0); SR.flipX = false; }
        else if ((Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed) && Stage.CanMove) { transform.Translate(-speed, 0, 0); SR.flipX = true; }
        else {ICWFirsted =false; isMoving = false; }//特定の入力がないとき
        if (Stage.Strange == 7) SR.color = new Color(230 / 255f, 230 / 255f, 230 / 255f, 220 / 255f); else SR.color = new Color(1, 1, 1, 1);

        time += Time.deltaTime * speed * 10;
        if(!isMoving) IdolTime += Time.deltaTime;
        else if(!ICWFirsted) {time+=0.2f; ICWFirsted = true;}//移動し始めた瞬間にtimeを0.2秒にすることで、歩き始めの瞬間に歩きの画像に切り替える
        if (time > 0.2f||(time>0.1f&&IdolTime>4f))//0.2秒ごとに画像を切り替える(ダッシュ中は3倍速で切り替える)
        {
            if(IdolTime>4f)time -= 0.1f;else time -= 0.2f;
            //Animetion
            if (isMoving)
            {
                //IsChangedWalk = true;//Walk.gif
                SR.sprite = SPW[SPWCount++]; SPICount = 0; SPIACount = 0;
                if (SPWCount >= SPW.Length) SPWCount = 0;
                IdolTime = 0f;
            }
            else
            {
                SR.sprite = SPI[SPICount++]; SPWCount = 0;
                if (SPICount >= SPI.Length) SPICount = 0;

                if (IdolTime > 4f)
                {
                    SR.sprite = SPIA[SPIACount++]; SPICount = 0;
                    if (SPIACount >= SPIA.Length) { SPIACount = 0; IdolTime = 0f; }
                }
            }
            if (TESTMODE) Stage.TESMODE = true; else Stage.TESMODE = false;
            Stage.TESStrange = TESStr;
        }
    }
}
