using UnityEngine;
using System.Collections;

public class MissileBehavior : MonoBehaviour
{
    public float MissileMovePower = 400;
    public float RotationalSpeed = 5;

    SpineMineBehavior closestSpineMine = null;

    void Start()
    {
        SpineMineBehavior[] spineMines = FindObjectsOfType(typeof(SpineMineBehavior)) as SpineMineBehavior[];
        closestSpineMine = spineMines[Random.Range(0, spineMines.Length)];

        /*for (int i = 0; i < spineMines.Length; i++)
        {
            Vector2 displacement = spineMines[i].transform.position - this.transform.position;

            if (closestSpineMine == null || displacement.SqrMagnitude() < closestSpineMine.transform.position.sqrMagnitude)
                closestSpineMine = spineMines[i];
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rigidbody2D.AddForce(MissileMovePower * this.transform.up);

        if (closestSpineMine != null)
        {
            Vector3 newDir = closestSpineMine.transform.position - transform.position;
            float newRot = Mathf.Atan2(newDir.y, newDir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, newRot - 90), Time.deltaTime);

            Debug.DrawLine(this.transform.position, closestSpineMine.transform.position, Color.red);
        }

        WrappedBoundaryData boundaryData = Camera.main.GetComponent<CameraBehavior>().isOutsideBoundary(this.transform.position, Vector2.zero);

        if (boundaryData.isWrapped)
            GameObject.Destroy(this.gameObject);
    }
}
