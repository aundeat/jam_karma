using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public float bounceHeight = 2;
    public float bounceFrequency = 17;

    public float swayAmount = 1;
    public float swaySpeed = 18;

    private float defaultRotation;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        defaultRotation = rb.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsMoving())
        {
            rb.rotation = defaultRotation;
        }

        if (IsMoving())
        {
            // Bounce and sway
            // Bouncing
            Vector2 bounce = new Vector2(0, Mathf.Sin(Time.fixedTime * bounceFrequency) * bounceHeight);
            rb.velocity += bounce;

            // Swaying
            float sway = Mathf.Sin(Time.fixedTime * swaySpeed) * swayAmount;
            rb.rotation += sway;
        }
    }


    private bool IsMoving()
    {

        return rb.velocity.magnitude > 0;
    }
}