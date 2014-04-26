using UnityEngine;
using System.Collections;

public class PlayerShipBehavior : MonoBehaviour
{
    private Vector2 colliderExtents;

    // Use this for initialization
    void Start()
    {
        // BoxCollider2D hack for obtaining size of object
        colliderExtents = GetComponent<BoxCollider2D>().size * .5f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 getColliderExtents()
    {
        return colliderExtents;
    }
}
