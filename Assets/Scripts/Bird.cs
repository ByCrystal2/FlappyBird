using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] public string Name;
    [SerializeField] public float Speed = 5;
    [SerializeField] public float JumpForce = 8;
    [SerializeField] public float FallForce = 8;
    private bool isJumping = false;
    public bool isDead;

    private float jumpForceIncrement = 0.25f; // Kuvvetin her güncellemede azaltýlacaðý miktar
    private float currentJumpForce; // Güncel zýplama kuvveti    
    private void Update()
    {
        if (!isDead)
        {
            Move();
            FallDown();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Zipliyor.");
                Jump();
            }
        }
    }
    public void Move()
    {
        Vector3 newPosition = Vector3.zero;
        if (!isJumping)
        {
            newPosition = transform.position + (new Vector3(Speed, 0, 0) * Time.deltaTime);            
        }
        else
        {
            newPosition = transform.position + (new Vector3(Speed * 0.7f, 0, 0) * Time.deltaTime);
        }
        transform.position = newPosition;
    }
    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpControl());
        }

    }
    public void FallDown()
    {
        if (!isJumping)
        {
            Vector3 newPosition = transform.position + (new Vector3(0, -FallForce, 0) * Time.deltaTime);
            transform.position = newPosition;
        }
        else
        {
            Vector3 newPosition = transform.position + (new Vector3(0, -FallForce/2, 0) * Time.deltaTime);
            transform.position = newPosition;
        }
    }
    IEnumerator JumpControl()
    {
        currentJumpForce = JumpForce;
        while (true)
        {
            if (currentJumpForce > 0)
            {
                
                float jumpDistance = currentJumpForce * Time.deltaTime;
                transform.position += new Vector3(0, jumpDistance, 0);
                currentJumpForce -= jumpForceIncrement;
            }
            else
            {
                isJumping = false;
                currentJumpForce = JumpForce; // Kuvveti resetle
                break;
            }
            yield return null;
        }
    }
    public void UpgradeSpeed()
    {
        Speed += (Speed*Time.deltaTime);
    }
   
}
