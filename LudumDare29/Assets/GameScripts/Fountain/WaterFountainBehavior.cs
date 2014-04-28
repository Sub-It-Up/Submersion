using UnityEngine;
using System.Collections;

public class WaterFountainBehavior : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        particleSystem.renderer.sortingLayerName = "PlayerLayer";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
