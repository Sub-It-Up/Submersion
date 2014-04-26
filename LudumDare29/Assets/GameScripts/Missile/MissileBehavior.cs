using UnityEngine;
using System.Collections;

public class MissileBehavior : MonoBehaviour
{
    public float MissileMovePower = 400;

    // Update is called once per frame
    void Update()
    {
        this.transform.rigidbody2D.AddForce(MissileMovePower * this.transform.up);

        WrappedBoundaryData boundaryData = Camera.main.GetComponent<CameraBehavior>().isOutsideBoundary(this.transform.position, Vector2.zero);

        if (boundaryData.isWrapped)
            GameObject.Destroy(this.gameObject);
    }
}
