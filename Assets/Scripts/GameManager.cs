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

    [Header("---Image Group---")]
    public Image waitImg;
    public Image TimeLimitImg;
    public Sprite[] Imgs;

    int Turn = 0;
    float pTime = 5.0f;
    int max=101, min=1, rand;
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

        if (Turn < 20)
            PChanceText.text = " ���� Ƚ�� : 20�� �� " + (Turn+1) + "��";

        else
        {  
            waitImg.sprite = Imgs[2];
            ResultText.text = " �𸣰ڽ��ϴ�..";
            return;
        }
        pTime -= Time.deltaTime;
        if (pTime < 0.0f)
        {
            TimeLimitImg.sprite = Imgs[3];
            TimeLimitImg.gameObject.SetActive(true);
        }

     
    }
 
    void ComSel(int min,int max)
    {
        if (gameOver)
            return;
        
        if (max <= min )
        {
            ResultText.text = "��ư�� �߸� �����̽��ϴ�. (�ٽ� ����)";
            gameOver = true;
            return;
        }
        rand = Random.Range(min, max);
      
      if(max - 1 == min)
        {
            ResultText.text = "����� ������ ���ڴ� " + rand + "�Դϴ�!!";
            gameOver = true;
            return;
        }

        RuleText.text = "����� ������ ���ڴ� " + rand + "�Դϱ�?";

    }
    private void TrueClick()
    {
        
        ResultText.text = "����� ������ ���ڴ� " + rand + "�Դϴ�!!";
        waitImg.sprite = Imgs[1];
        gameOver = true;
    }
    
    private void DownClick()
    {
        if (gameOver)
            return;

       if(rand ==1)
        {
            ResultText.text = "��ư�� �߸� �����ϼ̽��ϴ�. (�ٽ� ����)";
            gameOver = true;
            return;
        }
            max = rand;
            ComSel(min, max);
            Turn++;
            pTime = 5.0f;
    }

    private void UpClick()
    {
        if (gameOver)
            return;
        
        if(rand == 100)
        {
            ResultText.text = "��ư�� �߸� �����ϼ̽��ϴ�. (�ٽ� ����)";
            gameOver = true;
            return;
        }
       
            min = rand + 1;
            ComSel(min, max);
            Turn++;
            pTime = 5.0f;
    }

    private void ReplayClick()
    {
        SceneManager.LoadScene(0);
    }
}
