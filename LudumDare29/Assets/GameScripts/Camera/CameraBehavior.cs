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
    public PlayerBehavior[] PlayerObjects;
    public Material grappleMaterial;

    // Determines if a particular object needs to be wrapped
    // returns an object array
    // [0] -> true or false, whether wrapped or not wrapped
    // [1] -> the wrapped vector
    public WrappedBoundaryData isOutsideBoundary(Vector2 checkVector, Vector2 displaceVector)
    {
        // [0] -> whether a wrap was detected true or false
        // [1] -> the wrapped vector
        WrappedBoundaryData boundaryData = new WrappedBoundaryData();

        if (checkVector.y < camera.transform.position.y + (-WrapMaxSize - displaceVector.y))
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(checkVector.x, camera.transform.position.y + (WrapMaxSize - displaceVector.y));
        }
        else if (checkVector.y > WrapMaxSize + displaceVector.y)
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(checkVector.x, camera.transform.position.y + (-WrapMaxSize + displaceVector.y));
        }
        else if (checkVector.x < -2 * WrapMaxSize - displaceVector.x)
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(2 * WrapMaxSize + displaceVector.x, checkVector.y);
        }
        else if (checkVector.x > 2 * WrapMaxSize + displaceVector.x)
        {
            boundaryData.isWrapped     = true;
            boundaryData.wrappedVector = new Vector2(-2 * WrapMaxSize - displaceVector.x, checkVector.y);
        }

        return boundaryData;
    }

    void OnPostRender()
    {
        /*Vector3 worldMouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Vector3 mouseDir = (worldMouse - PlayerObjects[0].transform.position);
        mouseDir = new Vector3(mouseDir.x, mouseDir.y, 0);
        mouseDir.Normalize();
        RaycastHit2D raycastInfo = Physics2D.Raycast(PlayerObjects[0].transform.position + (PlayerObjects[0].GetColliderExtents().magnitude * mouseDir), mouseDir, Mathf.Infinity, 1 << LayerMask.NameToLayer("GroundLayer"));*/

        for (int i = 0; i < PlayerObjects.Length; i++)
        {
            if (PlayerObjects[i].ActiveGrapple)
            {
                RaycastHit2D raycastInfo = PlayerObjects[i].GetGrappleLocation();

                GL.PushMatrix();
                grappleMaterial.SetPass(0);
                GL.Begin(GL.LINES);
                GL.Color(grappleMaterial.color);
                GL.Vertex(PlayerObjects[i].transform.position);
                GL.Vertex(raycastInfo.point);
                GL.End();
                GL.PopMatrix();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        WrappedBoundaryData playerShipBoundaryData = isOutsideBoundary(PlayerShipObject.transform.position, PlayerShipObject.getColliderExtents());
        if (playerShipBoundaryData.isWrapped)
        {
            // temporarily set parent of Player Objects to allow them to also wrap
            for (int i = 0; i < PlayerObjects.Length; i++)
                PlayerObjects[i].transform.parent = PlayerShipObject.transform;

            PlayerShipObject.transform.position = playerShipBoundaryData.wrappedVector; // wrap

            // reset Player Objects parent to null
            for (int i = 0; i < PlayerObjects.Length; i++)
                PlayerObjects[i].transform.parent = null;
        }
    }
}
