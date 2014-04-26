using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {

    public float[] shipSpeed;
    private Camera cameraInfo;

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
	}
	
	// Update is called once per frame
	void Update () {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        this.transform.rigidbody2D.AddForce(new Vector2(horizontalMovement, verticalMovement));

        DetermineScreenWrap();
	}
}
