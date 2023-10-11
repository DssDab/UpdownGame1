using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("---Button Group---")]
    public Button TrueBtn;
    public Button UpBtn;
    public Button DownBtn;
    public Button ReplayBtn;

    [Header("---Text Group---")]
    public Text PChanceText;
    public Text RuleText;
    public Text ResultText;
    public Text TimeLimit;

    [Header("---Image Group---")]
    public Image waitImg;
    public Image TimeLimitImg;
    public Sprite[] Imgs;

    int Turn = 1;
    float pTime = 5.0f;
    int max=100, min=1, rand;
    bool gameOver;
    void Start()
    {
        if(TrueBtn != null) 
            TrueBtn.onClick.AddListener(TrueClick);
        if(UpBtn != null)
            UpBtn.onClick.AddListener(UpClick);
        if (DownBtn != null)
            DownBtn.onClick.AddListener(DownClick);
        if (ReplayBtn != null)
            ReplayBtn.onClick.AddListener(ReplayClick);
       
        ComSel( min,  max);
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (gameOver)
            return;

        pTime -= Time.deltaTime;
        TimeLimit.text = pTime.ToString("F2");
        if (pTime < 0.0f)
        {
            pTime = 0.0f;
            TimeLimitImg.sprite = Imgs[3];
            TimeLimitImg.gameObject.SetActive(true);
        }
        


    }
 
    void ComSel(int min,int max)
    {
        if (gameOver)
            return;
        
        if (max < min )
        {
            ResultText.text = "버튼을 잘못 누르셨습니다. (다시 진행)";
            gameOver = true;
            return;
        }
        rand = Random.Range(min, (max +1));
      
      if(max == min)
        {
            ResultText.text = "당신이 생각한 숫자는 " + rand + "입니다!!";
            gameOver = true;
            return;
        }

        RuleText.text = "당신이 생각한 숫자는 " + rand + "입니까?";

    }
    private void TrueClick()
    {
        
        ResultText.text = "당신이 생각한 숫자는 " + rand + "입니다!!";
        waitImg.sprite = Imgs[1];
        gameOver = true;
    }
    
    private void DownClick()
    {
    TimeLimitImg.gameObject.SetActive(false);
        if (gameOver)
            return;

       if(rand ==1)
        {
            ResultText.text = "버튼을 잘못 선택하셨습니다. (다시 진행)";
            gameOver = true;
            return;
        }
            max = rand-1;
            ComSel(min, max);
            Turn++;
            pTime = 5.0f;

            if (Turn <= 20)
            PChanceText.text = " 진행 횟수 : 20번 중 " + (Turn) + "번";

        else
        {  
            waitImg.sprite = Imgs[2];
            ResultText.text = " 모르겠습니다..";
            return;
        }

    }

    private void UpClick()
    {
    TimeLimitImg.gameObject.SetActive(false);
        if (gameOver)
            return;
        
        if(rand == 100)
        {
            ResultText.text = "버튼을 잘못 선택하셨습니다. (다시 진행)";
            gameOver = true;
            return;
        }
       
            min = rand + 1;
            ComSel(min, max);
            Turn++;
            pTime = 5.0f;

            if (Turn <= 20)
            PChanceText.text = " 진행 횟수 : 20번 중 " + (Turn) + "번";

        else
        {  
            waitImg.sprite = Imgs[2];
            ResultText.text = " 모르겠습니다..";
            return;
        }

    }

    private void ReplayClick()
    {
        SceneManager.LoadScene(0);
    }
}
