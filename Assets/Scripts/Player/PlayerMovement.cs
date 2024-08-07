using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public Vector2 movementVector;
    [HideInInspector] public float lastHorizontalVector, lastVerticalVector;
    [SerializeField] private float speed = 3.8f;
    private Animate animate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animate>();
        lastHorizontalVector = 1f;
        lastVerticalVector = 1f;
        // just set to default
        speed = 3.8f;
    }

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
     
        if(movementVector.x != 0)lastHorizontalVector = movementVector.x;
        if(movementVector.y != 0)lastVerticalVector = movementVector.y;

        animate.horizontal = movementVector.x;
        movementVector *= speed;
        rb.velocity = movementVector;
    }

    public void IncreaseMoveSpeed(float additionalSpeed)
    {
        speed += additionalSpeed;
    }
}
