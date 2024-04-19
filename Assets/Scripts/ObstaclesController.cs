using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [SerializeField] GameObject obstacle1;
    [SerializeField] GameObject obstacle2;
    private void Start()
    {
        float obstacles1RandomY = Random.Range(GameManager.instance.MinObstaclesDistanceY,GameManager.instance.MaxObstaclesDistanceY + 1) / 2;
        float obstacles2RandomY = -(Random.Range(GameManager.instance.MinObstaclesDistanceY,GameManager.instance.MaxObstaclesDistanceY + 1) / 2);
        Vector3 ob1 = new Vector3(obstacle1.transform.position.x, obstacles1RandomY, obstacle1.transform.position.z);
        Vector3 ob2 = new Vector3(obstacle2.transform.position.x, obstacles2RandomY, obstacle2.transform.position.z);
        obstacle1.transform.position = ob1;
        obstacle2.transform.position = ob2;
    }
}
