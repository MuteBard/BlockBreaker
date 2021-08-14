using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour
{
    [SerializeField] int row = 5;
    [SerializeField] int col = 10;
    [SerializeField] float startX = 3f;
    [SerializeField] float startY = 5f;
    [SerializeField] Transform breakableBlock;
    [SerializeField] Transform unBreakableBlock;
    [SerializeField] bool save;
    [SerializeField] string[] colors;
    [SerializeField] List<string> fieldTypes;
    [SerializeField] List<int> fieldTypeDepth;
    Dictionary<string, int> fieldTypesDict;
    Dictionary<string, float> breakableBlockPos;
    Dictionary<string, float> unBreakableBlockPos;
    Dictionary<string, Color> colorDictionary = new Dictionary<string, Color>(){
        {"black", Color.black},
        {"blue", Color.blue},
        {"clear", Color.clear},
        {"cyan", Color.cyan},
        {"gray", Color.gray},
        {"green", Color.green},
        {"magenta", Color.magenta},
        {"red", Color.red},
        {"white", Color.white},
        {"yellow", Color.yellow}
    };

    void Start()
    {
        breakableBlockPos = getBlockData(breakableBlock);
        unBreakableBlockPos = getBlockData(unBreakableBlock);
        fieldTypesDict = createFieldTypeDictionary(fieldTypes, fieldTypeDepth);
        blockGenerator();
    }

    private Dictionary<string, float> getBlockData(Transform block){
        float distX = block.GetComponent<Renderer>().bounds.size.x;
        float distY = block.GetComponent<Renderer>().bounds.size.y;
        float gap = .05f;
        return new Dictionary<string, float>()
        {
            {"xPos", distX + gap},
            {"yPos", distY + gap}
        };

    }

    private void blockGenerator()
    {
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if(setTypes(i, j)){
                    createRow(i, j, unBreakableBlock, unBreakableBlockPos, false);
                }else{
                    createRow(i, j, breakableBlock, breakableBlockPos, true);
                }
            }
        }
    }

    private Dictionary<string, int> createFieldTypeDictionary(List<string> listA, List<int> listB){
        if(listA.Count == listB.Count){
            int size = listB.Count;
            var newDict = new Dictionary<string, int>();
            for (int i = 0; i < size; i++){
                newDict.Add(listA[i], listB[i]);
            }
            return newDict;
        }else{
            Debug.Log("lists were unequal sizes");
            return new Dictionary<string, int>();
        }
    }

    private bool setTypes(int i, int j){
        if(fieldTypesDict.ContainsKey("top") &&  j > (row - 1) - fieldTypesDict["top"]){
            return true;
        }else if(fieldTypesDict.ContainsKey("top_slash") &&  j == (row - 1) - fieldTypesDict["top_slash"]){
            return true;
        }else if (fieldTypesDict.ContainsKey("bottom") &&  j < fieldTypesDict["bottom"]){
            return true;
        }else if (fieldTypesDict.ContainsKey("bottom_slash") &&  j == fieldTypesDict["bottom_slash"]){
            return true;
        }else if(fieldTypesDict.ContainsKey("left")  &&  i < fieldTypesDict["left"]){
            return true;
        }else if(fieldTypesDict.ContainsKey("left_slash")  &&  i == fieldTypesDict["left_slash"]){
            return true;
        }else if(fieldTypesDict.ContainsKey("right")  &&  i > (col - 1) - fieldTypesDict["right"]){
            return true;
        }else if(fieldTypesDict.ContainsKey("right_slash")  &&  i == (col - 1) - fieldTypesDict["right_slash"]){
            return true;
        }else{
            return false;
        }    
    }

    private void createRow(int i, int j, Transform blockType,  Dictionary<string, float> blockPos, bool addColor){
        var newGameObject = Instantiate(blockType, new Vector2((i * blockPos["xPos"]) + startX, (j * blockPos["yPos"]) + startY), Quaternion.identity);
        if(newGameObject && addColor){
            newGameObject.GetComponent<Renderer>().material.color = selectColor(i,j);
        }
    }

    private Color selectColor(int numberi , int numberj){
        int index = (numberi + numberj) % colors.Length;
        string color = colors[index];
        return colorDictionary[color];
    }
}


