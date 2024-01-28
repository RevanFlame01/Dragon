using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
   //[HideInInspector] [SerializeField] private int Money;
 //  [HideInInspector] [SerializeField] private int Stamina;
  // [HideInInspector] [SerializeField] private int Speed;
    private int allScore;
     private int Score;
     public int StatusProlog;
    // [HideInInspector] [SerializeField] private int Prolog;

    public Text scorText;

    public static int item = 0;

    
    public GameObject panel;
    public GameObject sold;
    void Start()
    {

      //  Money = PlayerPrefs.GetInt("Money");
    //    Stamina = PlayerPrefs.GetInt("Stamina");
       // Speed = PlayerPrefs.GetInt("Speed");
        allScore = PlayerPrefs.GetInt("allscore");
        Score = PlayerPrefs.GetInt("score");
        item = PlayerPrefs.GetInt("item");
        PlayerPrefs.SetInt("allscore", allScore + Score);
        StatusProlog = PlayerPrefs.GetInt("Prolog");
    }
    void Update()
    {
        
        scorText.text = "Score: " + allScore;
        Score = PlayerPrefs.GetInt("score");
        // Money = PlayerPrefs.GetInt("Money");
        //     Stamina = PlayerPrefs.GetInt("Stamina");
        // Speed = PlayerPrefs.GetInt("Speed");
        PlayerPrefs.SetInt("allscore", allScore);
        StatusProlog = PlayerPrefs.GetInt("Prolog");

        if (item ==1)
        {
            sold.SetActive(true);
        }
        else
        {
            sold.SetActive(false);
        }
    }

    public void Panel()
    {
        panel.SetActive(true);

    }

    public void Exit()
    {
        panel.SetActive(false);
    }

    public void Buy()
    {
        if (allScore >= 100)
        {
            PlayerPrefs.SetInt("allscore", allScore -= 100);
            item = 1;
            PlayerPrefs.SetInt("item", item);
            
        }
    }
}
