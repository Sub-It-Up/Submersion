using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{
    public int playerNum = 1;
    public float PlayerMaxSpeed = 2;    // Max Player Speed
    public float PlayerMoveForce = 7;    // Player Move Force
    public float PlayerJumpForce = 200;  // Player Jump Force
    public float GroundDisplace = .05f; // Displacement of distToGround to make sure it extends beyond collision boundaries

    private Vector2 colliderExtents; // the extents of the player collision box
    private Animator playerAnimator;

    // Use this for initialization
    void Start()
    {
        colliderExtents = GetComponent<BoxCollider2D>().size * .5f;
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo playerAnimatorState = playerAnimator.GetCurrentAnimatorStateInfo(0); // only one layer (0)
        // cast a ray downward, looking for only GroundLayer objects -> ("1 << " is unknown to me, but it's the way to do it, it seems)
        RaycastHit2D raycastInfo = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y - (colliderExtents.y + .005f)), -Vector2.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("GroundLayer"));

        if (raycastInfo)
            Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y - (colliderExtents.y + .005f)), raycastInfo.point, Color.red);

        if (Input.GetAxis("Horizontal" + playerNum) < 0)
        {
            if (!playerAnimatorState.IsName("Run") || this.transform.localScale.x > 0)
            {
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                playerAnimator.Play("Run");
            }

            this.transform.rigidbody2D.AddForce(new Vector2(-PlayerMoveForce, 0));
        }
        else if (Input.GetAxis("Horizontal" + playerNum) > 0)
        {
            if (!playerAnimatorState.IsName("Run") || this.transform.localScale.x < 0)
            {
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                playerAnimator.Play("Run");
            }

            this.transform.rigidbody2D.AddForce(new Vector2(PlayerMoveForce, 0));
        }
        else if (!playerAnimatorState.IsName("Idle"))
            playerAnimator.Play("Idle");

        float toRayPointSqrDistance = Vector2.SqrMagnitude(raycastInfo.point - new Vector2(this.transform.position.x, this.transform.position.y));
        float distToSqrGround = (colliderExtents.y + GroundDisplace) * (colliderExtents.y + GroundDisplace);

        // make sure only jump when grounded
        if ((toRayPointSqrDistance < distToSqrGround) && Input.GetAxis("Jump" + playerNum) > 0)
            this.transform.rigidbody2D.AddForce(new Vector2(0, PlayerJumpForce));

        // limit speed to the PlayerMaxSpeed
        if (this.transform.rigidbody2D.velocity.sqrMagnitude > PlayerMaxSpeed * PlayerMaxSpeed)
            this.transform.rigidbody2D.velocity = this.transform.rigidbody2D.velocity.normalized * PlayerMaxSpeed;
    }

    public Vector2 GetColliderExtents()
    {
        return colliderExtents;
    }
}
