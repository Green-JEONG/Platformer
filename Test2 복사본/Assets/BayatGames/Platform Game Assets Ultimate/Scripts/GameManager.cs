using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panel;
    //public GameObject gameoverPanel;
    public GameObject gameoverText;
    public Text timeText;

    private bool isGameover;
    private float surviveTime;
    //public GameObject Exit_Button;
    // Start is called before the first frame update
    void Start()
    {
        isGameover = false;
        panel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover){
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }
        else{
            if(Input.GetKeyDown(KeyCode.S)){
                SceneManager.LoadScene("KOJEONG");
            }
        }

        
       if (Input.GetKeyDown(KeyCode.Escape))
       {
             panel.SetActive(!panel.activeSelf);
       }
        
    }
    public void EndGame(){
    isGameover = true;
    gameoverText.SetActive(true);
  //  gameoverPanel.SetActive(true);
    }

}
