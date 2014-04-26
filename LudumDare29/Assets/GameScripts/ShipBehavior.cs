using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {

    private Camera cameraInfo;
    private float distToGround;

    private void DetermineScreenWrap()
    {
        if (this.transform.position.y < -cameraInfo.orthographicSize)
            this.transform.position = new Vector2(this.transform.position.x, cameraInfo.orthographicSize);
        else if (this.transform.position.y > cameraInfo.orthographicSize)
            this.transform.position = new Vector2(this.transform.position.x, -cameraInfo.orthographicSize);
        else if (this.transform.position.x < -2 * cameraInfo.orthographicSize)
            this.transform.position = new Vector2(2 * cameraInfo.orthographicSize, this.transform.position.y);
        else if (this.transform.position.x > 2 * cameraInfo.orthographicSize)
            this.transform.position = new Vector2(-2 * cameraInfo.orthographicSize, this.transform.position.y);
    }

	// Use this for initialization
	void Start () {
        cameraInfo = Camera.main;
        distToGround = (GetComponent<BoxCollider2D>().size * .5f).y;
        Debug.Log(distToGround);
	}
	
	// Update is called once per frame
	void Update () {

        //float horizontalMovement = Input.GetAxis("Horizontal");
        //float verticalMovement = Input.GetAxis("Vertical");

        bool isGrounded = Physics2D.Raycast(this.transform.position, -Vector2.up, distToGround + .01f);
        Debug.DrawLine(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y + -1.0f * (distToGround + .01f)), Color.red);

        if (Input.GetKey(KeyCode.A))
            this.transform.rigidbody2D.AddForce(new Vector2(-7, 0));
        else if (Input.GetKey(KeyCode.D))
            this.transform.rigidbody2D.AddForce(new Vector2(7, 0));
        //this.transform.rigidbody2D.velocity = new Vector2(this.transform.rigidbody2D.velocity.x * .99f, this.transform.rigidbody2D.velocity.y * .99f);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            this.transform.rigidbody2D.AddForce(new Vector2(0, 200));

        if (this.transform.rigidbody2D.velocity.sqrMagnitude > 2 * 2)
            this.transform.rigidbody2D.velocity = this.transform.rigidbody2D.velocity.normalized * 2;

        DetermineScreenWrap();
	}
}
