using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    public GameObject tapToStart; 
    public GameObject zigZagPanel; 
    public GameObject gameOverMenuPanel;    
    public Text score;         
    public Text highScore1;   
    public Text highScore2;     

   
    private void Awake()
    {
       
        if(instance == null)
        {
            instance = this;
        }
    }


    
    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    
    public void GameStart()
    {
        tapToStart.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("PanelMoveUp");
    }

   
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverMenuPanel.SetActive(true);
    }


    
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    
    void Update()
    {
        
    }
}
