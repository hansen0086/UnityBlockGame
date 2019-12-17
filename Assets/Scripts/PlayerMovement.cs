
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody rb;
    public float sidewaysForce = 500f;
    public float forwardForce = 1000f;
    // Start is called before the first frame update

    private float width;
    private float height;


    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        //touch screen control

        // Handle screen touches.
        if (Input.touchCount > 0)
        {
            width = (float)Screen.width / 2.0f;
            height = (float)Screen.height / 2.0f;
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            pos.x = (pos.x - width) / width;
            pos.y = (pos.y - height) / height;

            if (pos.x >= 0.5)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (pos.x < 0.5)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }


        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();

        }
    }

}
