using UnityEngine;
using System.Collections;

public class SpineMineBehavior : MonoBehaviour
{
    public float MovePower = 10;
    public float MaxSpeed = 2;
    public AudioClip explosionSound;

    private Vector2 movementDirection = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        movementDirection = GameObject.Find("MainPlayerShip").transform.position - this.transform.position;
        movementDirection.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.rigidbody2D.velocity.sqrMagnitude < MaxSpeed * MaxSpeed)
            this.transform.rigidbody2D.AddForce(MovePower * movementDirection);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "MainPlayerShip" || collision.transform.name.Contains("missile"))
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            GameObject.Destroy(this.gameObject);

            if (collision.transform.name.Contains("missile"))
                GameObject.Destroy(collision.transform.gameObject);
        }
    }
}
