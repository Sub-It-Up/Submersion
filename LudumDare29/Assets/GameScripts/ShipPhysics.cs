using UnityEngine;
using System.Collections;

public class ShipPhysics : MonoBehaviour
{
  public float balistScale = 0.2f;//value to scale-down balist force with
  
	public float balist;                   //floating position of the submarine
  float dirDeg;                   //direction the sub is pointing in radians
	public float thrust = 0.0f;            //mag of the thrust from the engines
  public float maxThrust = 5.0f;         //max thrust (and min when negated)

	// Use this for initialization
	void Start()
	{
     //get y position of the sub
    balist = this.transform.position.y;
	}
	/*
	// Update is called once per frame
	void Update()
	{
	
	}
	*/
  void FixedUpdate()
  {
     //get angle of the ship
    dirDeg = this.transform.rotation.z * Mathf.PI;
     //check the bounds of the thrust
    if (thrust > maxThrust)
      thrust = maxThrust;
    else if (thrust < -maxThrust)
      thrust = -maxThrust;

    UpdateVelocity();
    UpdateBalist();
  }
	 //update and apply the force from the balist tanks
  private void UpdateBalist()
  {
    Vector2 balForce = new Vector2(0.0f, balist - this.transform.position.y);
    this.rigidbody2D.velocity += balForce * balistScale * Time.fixedDeltaTime;
  }
   //update the ships velocity
  private void UpdateVelocity()
  {
     //gives us a direction vector in the direction to apply thrust
    Vector2 thrustVec = new Vector2(Mathf.Cos(dirDeg), Mathf.Sin (dirDeg));
	  Debug.Log(dirDeg);
	  Debug.Log(thrustVec);
    thrustVec *= thrust;
     //apply thrust to the velocity of the ship
    this.rigidbody2D.velocity += thrustVec * Time.fixedDeltaTime;
  }
}
