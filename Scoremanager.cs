using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Scoremanager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public Text secondhighscoreText;
    public Text thirdhighscoreText;
    public Playercontrol oyuncu;
    public float tempscoreCount;
    public float scoreCount;
    public float highscoreCount;
    public float secondhighscoreCount;
    public float thirdhighscoreCount;
    public float pasthighscore;
    public float pastsecondScore;
    public float pastthirdScore;
    public float pointsperSecond;
    public bool scoreIncreasing;
    public bool doublee;
    // Start is called before the first frame update
    void Start()
    {
        oyuncu = FindObjectOfType<Playercontrol>();
        if(PlayerPrefs.HasKey("Highscore : ") == true)
        {
            pasthighscore = PlayerPrefs.GetFloat("Highscore : ");
        }
        if (PlayerPrefs.HasKey("Second Highscore : ") == true)
        {
           pastsecondScore = PlayerPrefs.GetFloat("Second Highscore : ");
        }
        if (PlayerPrefs.HasKey("Third Highscore : ") == true)
        {
            pastthirdScore = PlayerPrefs.GetFloat("Third Highscore : ");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyuncu.contact2 == true)
        {
            scoreIncreasing = true;
        }
        if (scoreIncreasing==true)
        {
            if(oyuncu.doublepointActive==false)
            {
                scoreCount += pointsperSecond * Time.deltaTime;
                tempscoreCount = scoreCount ;
            }
            else if(oyuncu.doublepointActive==true)
            {
                if(doublee == true)
                {
                    scoreCount = tempscoreCount;
                }
                doublee = false;
                scoreCount += pointsperSecond * 4 * Time.deltaTime;
            }
        }
       
        



        if(oyuncu.doublepointActive==false)
        {
            scoreText.text = "Score : " + Mathf.Round(scoreCount);
        }
        else if (oyuncu.doublepointActive==true)
        {
            scoreText.text = "Score 2X : " + Mathf.Round(scoreCount);
        }
        highscoreText.text = "Highscore : " + Mathf.Round(pasthighscore);
        secondhighscoreText.text = "Second Highscore : " + Mathf.Round(pastsecondScore);
        thirdhighscoreText.text = "Third Highscore : " + Mathf.Round(pastthirdScore);

    }
    public void Addpoint(int givescore)
    {
        scoreCount += givescore;
    }
    public void skorislemi()
    {
        // Skorlarýn yer deðiþtirme algoritmasý
        if (scoreCount > pastthirdScore)
        {
            thirdhighscoreCount = scoreCount;
            PlayerPrefs.SetFloat("Third Highscore : ", thirdhighscoreCount);
            if (scoreCount > pastsecondScore)
            {
                secondhighscoreCount = scoreCount;
                PlayerPrefs.SetFloat("Second Highscore : ", secondhighscoreCount);
                PlayerPrefs.SetFloat("Third Highscore : ", pastsecondScore);
            }
            if (scoreCount > pasthighscore)
            {
                highscoreCount = scoreCount;
                PlayerPrefs.SetFloat("Highscore : ", highscoreCount);
                PlayerPrefs.SetFloat("Second Highscore : ", pasthighscore);
                PlayerPrefs.SetFloat("Third Highscore : ", pastsecondScore);
            }
        }
    }
   
  
}
