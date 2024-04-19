using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclesPrefab;
    [SerializeField] GameObject MapPrefab;
    public Vector3 LastObstaclesPosition = Vector3.zero;
    public float ObstaclesXDistance = 4f;
    private bool isFirst;
    public GameObject LastMap;
    private List<GameObject> Maps = new List<GameObject>();
    private GameObject _lastObstacle;
    public static ObstaclesManager instance { get; set; }
    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        isFirst = true;
    }
    public void HowManyCreateObstacles(int _count)
    {
        GameObject _newMap = Instantiate(MapPrefab);
        for (int i = 0; i < _count; i++)
        {
            CreateObstacles(_newMap.transform);
        }
        LastMap = _newMap.gameObject;
        Maps.Add(LastMap);
        _lastObstacle.transform.GetComponentInChildren<RemoveLasMapControl>().gameObject.GetComponent<BoxCollider2D>().enabled = true;
        GameObject _newMapBacgroundObj = _newMap.transform.GetChild(0).gameObject;
        
        
        if (_newMap.transform.GetChild(_newMap.transform.childCount - 1).TryGetComponent(out ObstaclesController obstracle))
        {
            Vector3 _MapBacgroundPoistion = new Vector3((_newMap.transform.GetChild(1).position.x + obstracle.transform.position.x)/2, _newMapBacgroundObj.transform.position.y, _newMapBacgroundObj.transform.position.z);
            _newMapBacgroundObj.transform.position = _MapBacgroundPoistion; 
        }
                      
        
        
    }
    private void Update()
    {        
        if (GameManager.instance.player.transform.position.x >= LastObstaclesPosition.x / 2)
        {
            if (Maps.Count < 3)
            {
                HowManyCreateObstacles(GameManager.instance.ObstaclesGenerateCount);
            }
        }
        
    }
    public void RemoveLastMap(GameObject _lastMap)
    {
        if (Maps.Count > 0)
        {
            int index = Maps.IndexOf(_lastMap) - 1;
            if (index >= 0)
            {
                Debug.Log(index);
                Destroy(Maps[index]);
                Maps.RemoveAt(index);
            }
            GameManager.instance.player.UpgradeSpeed();
        }
        
    }
    private void CreateObstacles(Transform _newMap)
    {
        if (isFirst)
        {            
            GameObject _newObstacles = Instantiate(obstaclesPrefab, GameManager.instance.obstaclesStartPos,Quaternion.identity,_newMap);
            Debug.Log("LastPos Zero => " + _newObstacles.transform.position);
            LastObstaclesPosition = _newObstacles.transform.position;                      
            isFirst = false;
            _lastObstacle = _newObstacles;
        }
        else
        {
            GameObject _newObstacles1 = Instantiate(obstaclesPrefab, new Vector3(LastObstaclesPosition.x+ ObstaclesXDistance, LastObstaclesPosition.y,LastObstaclesPosition.z), Quaternion.identity, _newMap);
            Debug.Log("LastPos Not Zero => " + _newObstacles1.transform.position);
            LastObstaclesPosition = _newObstacles1.transform.position;
            _lastObstacle = _newObstacles1;
        }

    }
}
