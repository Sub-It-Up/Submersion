using UnityEngine;
using System;
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
    public Transform[] FollowCameraObjects;
    public PlayerBehavior[] PlayerObjects;
    public Material grappleMaterial;

    private float totalTime = 0;
    private int minesDestroyed = 0;
    private float currentHealth = 100;
    private float maxHealth = 100;

    public int MinesDestroyed
    {
        get { return minesDestroyed; }
        set { minesDestroyed = value; }
    }

    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

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
        else if (checkVector.y > camera.transform.position.y + WrapMaxSize + displaceVector.y)
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
            WrappedBoundaryData playerBoundaryData = isOutsideBoundary(PlayerObjects[i].transform.position, PlayerObjects[i].GetColliderExtents());

            if (PlayerObjects[i].ActiveGrapple && !playerBoundaryData.isWrapped)
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

        this.transform.position = new Vector3(this.transform.position.x, PlayerShipObject.transform.position.y, this.transform.position.z);

        for (int i = 0; i < FollowCameraObjects.Length; i++)
            FollowCameraObjects[i].position = new Vector3(FollowCameraObjects[i].position.x, this.transform.position.y, FollowCameraObjects[i].position.z);

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

        totalTime += Time.deltaTime;

        TimeSpan t = TimeSpan.FromSeconds(totalTime);
        string formattedTime = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);

        GameObject.Find("TotalTime_Text").GetComponent<GUIText>().text = formattedTime;
        GameObject.Find("MinesDestroyed_Text").GetComponent<GUIText>().text = Convert.ToString(minesDestroyed);
        GameObject.Find("Health_Text").GetComponent<GUIText>().text = Convert.ToString((((int)currentHealth / maxHealth) * 100)) + "%";
    }
}
