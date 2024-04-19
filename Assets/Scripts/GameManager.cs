using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float MaxObstaclesDistanceY = 16f;
    public float MinObstaclesDistanceY = 15f;
    public int ObstaclesGenerateCount = 5;
    public Vector3 obstaclesStartPos = Vector3.zero;
    public Bird player;
    public static GameManager instance { get; set; }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindWithTag("Player").GetComponent<Bird>();        
        ObstaclesManager.instance.HowManyCreateObstacles(ObstaclesGenerateCount);

    }
}
