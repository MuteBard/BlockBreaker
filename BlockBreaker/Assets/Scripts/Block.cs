using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //config params (things we tune before the game)
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //cached reference (external game objects we import)
    Level level;
    GameSession gameSession;

    //state variables
    [SerializeField] int timesHit;

    
    private void Start(){
        level = FindObjectOfType<Level>();
        gameSession = FindObjectOfType<GameSession>();
        //Every block will signal to Level of its existance and then level counter will increase
        CountBreakableBlocks();

    }
    
    private void CountBreakableBlocks(){
        if (tag == "breakable")
        {
            level.CountBlocks();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(tag == "breakable"){
            HandleHit();
        }
    }

    private void HandleHit(){
        timesHit++;
        TriggerSparklesVFX();
        if(timesHit >= maxHits){
            DestroyBlock();
        }
        else{
            gameSession.AddToScoreMinor();
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite(){

        if(!!hitSprites[timesHit - 1]){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
    }


    private void DestroyBlock(){
        level.BlockDestroyed();
        gameSession.AddToScore();
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX(){
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
