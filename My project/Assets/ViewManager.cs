using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public CinemachineVirtualCamera startingCamera; // The camera for the initial player.
    public CinemachineVirtualCamera[] playerCameras; // An array of player cameras.
    public GameObject[] gameObjects;
    private int currentPlayerIndex = 0; // Index to track the current player camera.

    void Start()
    {
        //startingCamera.Priority = 10; // Set a high priority for the starting camera.
        gameObjects = GameObject.FindGameObjectsWithTag("camera");
        Debug.Log(gameObjects[1].name);
    }
    void Update()
    {
        
    }
}
