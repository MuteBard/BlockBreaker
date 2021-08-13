## DEV-24, Resolving State reset when a scene is hit

![](../../images/BlockBreaker/DEV-24-A.png)

![](../../images/BlockBreaker/DEV-24-B.png)


remove this line of code `FindObjectOfType<GameStatus>().ResetScore();` from LoseCollider
![](../../images/BlockBreaker/DEV-24-C.png)



removed this line of code `this.gameObject.SetActive(false);` to get music running again at start up
![](../../images/BlockBreaker/DEV-24-D.png)

We also renamed GameStatus to GameSession within the 
scripts reference code
scripts name in unity
object reference in the Hierarchy via the prefab