using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float jumpHeight; // impulso en el eje vertical
    public float strengthH; // impulso en el eje horizontal

    private Rigidbody2D player;
    private bool onTheFloor;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody2D>();
        onTheFloor = false;
    }
	
    void FixedUpdate()
    {
        // Flechitas
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        if (onTheFloor && moveV > 0)
        {
            // estamos en el piso... podemos saltar :)
            player.AddForce(new Vector2(moveH, jumpHeight), ForceMode2D.Impulse);
        }

        if (!onTheFloor)
        {
            // nos movemos de costado en cualquier momento en el aire. Multiplicado por fuerza para darle mas power
            player.AddForce(new Vector2(moveH * strengthH, 0));
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Background"))
        {
            // Chocamos contra el piso
            onTheFloor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Background"))
        {
            // Nos fuimos del piso
            onTheFloor = false;
        }
    }
}
