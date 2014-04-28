using UnityEngine;
using System.Collections;

public class SpineMineBehavior : MonoBehaviour
{
    public float MovePower = 10;
    public float MaxSpeed = 2;
    public AudioClip explosionSound;
    public GameObject WaterLeak;

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
            Transform spineMineExplosion = this.transform.FindChild("Spinemine_Explode");
            spineMineExplosion.parent = null;
            spineMineExplosion.particleSystem.Play();
            GameObject.Destroy(spineMineExplosion.gameObject, spineMineExplosion.particleSystem.duration); // destroy this explosion after the duration

            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            GameObject.Destroy(this.gameObject);

            Camera.main.GetComponent<CameraBehavior>().MinesDestroyed++;

            if (collision.transform.name.Contains("missile"))
            {
                GameObject.Destroy(collision.transform.gameObject);
            }
            else if (collision.transform.name == "MainPlayerShip")
            {
                Vector2 average_normal = Vector2.zero;
                Vector2 average_point = Vector2.zero;

                foreach (ContactPoint2D contact in collision.contacts)
                {
                    average_normal += contact.normal;
                    average_point += contact.point;
                }

                average_normal /= collision.contacts.Length;
                average_point /= collision.contacts.Length;

                float angle = Mathf.Atan2(-average_normal.y, -average_normal.x) * Mathf.Rad2Deg;

                GameObject newLeak = (GameObject)GameObject.Instantiate(WaterLeak, average_point, Quaternion.Euler(new Vector3(0, 0, angle - 90)));
                newLeak.transform.parent = collision.transform;
            }
        }
    }
}
