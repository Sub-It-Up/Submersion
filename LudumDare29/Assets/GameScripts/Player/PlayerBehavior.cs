using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour 
{
    public float PlayerMaxSpeed  = 2;    // Max Player Speed
    public float PlayerMoveForce = 7;    // Player Move Force
    public float PlayerJumpForce = 200;  // Player Jump Force
    public float GroundDisplace  = .05f; // Displacement of distToGround to make sure it extends beyond collision boundaries

    private Vector2 colliderExtents; // the extents of the player collision box

	// Use this for initialization
	void Start() 
    {
        colliderExtents = GetComponent<BoxCollider2D>().size * .5f;
	}
	
	// Update is called once per frame
	void Update() 
    {
        // cast a ray downward, looking for only GroundLayer objects -> ("1 << " is unknown to me, but it's the way to do it, it seems)
        RaycastHit2D raycastInfo = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y - (colliderExtents.y + .005f)), -Vector2.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("GroundLayer"));

        if (raycastInfo)
            Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y - (colliderExtents.y + .005f)), raycastInfo.point, Color.red);

        if (Input.GetKey(KeyCode.A))
            this.transform.rigidbody2D.AddForce(new Vector2(-PlayerMoveForce, 0));
        else if (Input.GetKey(KeyCode.D))
            this.transform.rigidbody2D.AddForce(new Vector2(PlayerMoveForce, 0));

        float toRayPointSqrDistance = Vector2.SqrMagnitude(raycastInfo.point - new Vector2(this.transform.position.x, this.transform.position.y));
        float distToSqrGround = (colliderExtents.y + GroundDisplace) * (colliderExtents.y + GroundDisplace);

        // make sure only jump when grounded
        if ((toRayPointSqrDistance < distToSqrGround) && Input.GetKeyDown(KeyCode.Space))
            this.transform.rigidbody2D.AddForce(new Vector2(0, PlayerJumpForce));

        // limit speed to the PlayerMaxSpeed
        if (this.transform.rigidbody2D.velocity.sqrMagnitude > PlayerMaxSpeed * PlayerMaxSpeed)
            this.transform.rigidbody2D.velocity = this.transform.rigidbody2D.velocity.normalized * PlayerMaxSpeed;
	}
}
