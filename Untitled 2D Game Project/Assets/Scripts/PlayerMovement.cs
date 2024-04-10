using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float vertical;
    private float horizontal;
    private Vector2 movementVector;

    private Vector2 lookVector;

    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetData();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector * speed * Time.fixedDeltaTime);
        rb.MoveRotation(Quaternion.LookRotation(lookVector, Vector3.back));
    }

    private void GetData()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        movementVector = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - rb.position);
        lookVector = (mousePos - rb.position).normalized;
    }
}
