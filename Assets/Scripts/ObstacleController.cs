using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collider degdi");
        if (collision.gameObject.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            //collision.gameObject.GetComponent<Bird>().isDead = true;
        }
    }
}
