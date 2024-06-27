using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float moveDistance = 5f; 

    private Vector3 originalPosition;
    private bool isMovingRight = true;

    void Start()
    {
        
        originalPosition = transform.position;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            isMovingRight = !isMovingRight;
        }

        if (isMovingRight)
        {
            
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            
            if (transform.position.x >= originalPosition.x + moveDistance)
            {
                isMovingRight = false; 
            }
        }
        else
        {
            
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            
            if (transform.position.x <= originalPosition.x - moveDistance)
            {
                isMovingRight = true; 
            }
        }
    }
}
