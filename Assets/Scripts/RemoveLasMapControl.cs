using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLasMapControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObstaclesManager.instance.RemoveLastMap(transform.parent.parent.gameObject);
        }
    }
}
