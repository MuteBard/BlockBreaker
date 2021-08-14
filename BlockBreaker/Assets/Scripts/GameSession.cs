using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    //config params
    [Range(1f, 10f)] [SerializeField] float slowness = 1f;
    [Range(1f, 10f)] [SerializeField] float swiftness = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // State
    [SerializeField] int currentScore = 0;


    void Awake(){
        //find all game objects with this tag
        int gameObjectsCount = FindObjectsOfType<GameSession>().Length;
        //check the number of game objects with this tag to see if it is over 1
        if(gameObjectsCount > 1){
            //if so then destroy this particular gameobject that this script is on
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }else{
            //if not then stay alive
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        float speed = (1f * swiftness) / slowness;
        Time.timeScale = speed;
    }


    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString(); 
    }
    public void AddToScoreMinor(){
        currentScore += pointsPerBlockDestroyed / 4;
        scoreText.text = currentScore.ToString(); 
    }

    public void ResetScore(){
        Destroy(this.gameObject);
    }
}
