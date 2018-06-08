using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardVelocity = 4000f;
    public float sideVelocity = 1500f;

    private void Start()
    {
        forwardVelocity = PlayerPrefs.GetFloat("VelocidadPlayer");
        if (forwardVelocity == 0)
        {
            forwardVelocity = 4000f;
        }
    }

    void FixedUpdate ()
    {
        if (!GameManager.GameIsOver)
        {
            rb.velocity = new Vector3(0, 0, forwardVelocity * Time.deltaTime);

            if (Input.GetKey("d")) //si el player esta apretando la tecla "d"
            {
                rb.velocity = rb.velocity + new Vector3(sideVelocity * Time.deltaTime, 0, 0);
            
            }

            if (Input.GetKey("a")) //si el player esta apretando la tecla "a"
            {
                rb.velocity = rb.velocity + new Vector3(-sideVelocity * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

}
