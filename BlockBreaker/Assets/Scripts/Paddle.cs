using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddleHeight = 1f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(getWorldX(), getWorldY());
        paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);
        transform.position = paddlePos;
    }

    float getWorldX(){
        float xPercentage = Input.mousePosition.x / Screen.width;
        return xPercentage * screenWidthInUnits;
    }

    float getWorldY(){ 
        return paddleHeight;
    }

    
}
