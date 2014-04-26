using UnityEngine;
using System.Collections;

public struct WrappedBoundaryData
{
    public bool isWrapped;
    public Vector2 wrappedVector;
}

public class CameraBehavior : MonoBehaviour
{
    public float WrapMaxSize = 5;               // The max value for when to wrap
    public PlayerShipBehavior PlayerShipObject; // The player ship object to keep track of

    // Determines if a particular object needs to be wrapped
    // returns an object array
    // [0] -> true or false, whether wrapped or not wrapped
    // [1] -> the wrapped vector
    public WrappedBoundaryData isOutsideBoundary(Vector2 checkVector, Vector2 displaceVector)
    {
        // [0] -> whether a wrap was detected true or false
        // [1] -> the wrapped vector
        WrappedBoundaryData boundaryData = new WrappedBoundaryData();

        if (checkVector.y - displaceVector.y < -WrapMaxSize)
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(checkVector.x, WrapMaxSize - displaceVector.y);
        }
        else if (checkVector.y + displaceVector.y > WrapMaxSize)
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(checkVector.x, -WrapMaxSize + displaceVector.y);
        }
        else if (checkVector.x - displaceVector.x < -2 * WrapMaxSize)
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(2 * WrapMaxSize - displaceVector.x, checkVector.y);
        }
        else if (checkVector.x + displaceVector.x > 2 * WrapMaxSize)
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(-2 * WrapMaxSize + displaceVector.x, checkVector.y);
        }

        return boundaryData;
    }

    // Update is called once per frame
    void Update()
    {
        WrappedBoundaryData playerShipBoundaryData = isOutsideBoundary(PlayerShipObject.transform.position, PlayerShipObject.getColliderExtents());
        if (playerShipBoundaryData.isWrapped)
            PlayerShipObject.transform.position = playerShipBoundaryData.wrappedVector;
    }
}
