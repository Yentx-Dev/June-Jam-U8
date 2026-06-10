using System;
using System.Drawing;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpit : MonoBehaviour
{
    public int spitStrength;
    public float minSize;
    public int maxSpits;
    private float maxSize; // set to what the player is originally on start
    private float sizeDelta;
    private InputAction spitAction;
    public GameObject trashObject;
    private ThrowableTrash currTrash;
    public Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spitAction = InputSystem.actions.FindAction("Spit");
        maxSize = GetComponent<Transform>().localScale.x;
        sizeDelta = (maxSize - minSize)/(maxSpits);
        spitAction.started += context =>{
            Transform playerTransform = GetComponent<Transform>();
            float currSize = playerTransform.localScale.x;
            if (currSize <= minSize) {return;} // Don't spit if at min size
            spitTrash();
            float newSize = (float) Math.Max(minSize, currSize - sizeDelta);
            playerTransform.localScale = new Vector3(newSize, newSize, newSize);
            Debug.Log("Trash was spit");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void spitTrash()
    {
        // Spawn trash
        GameObject spawnedTrash = Instantiate(trashObject, spawnPoint.position, Quaternion.identity);
        currTrash = spawnedTrash.GetComponent<ThrowableTrash>();
        // Throw trash
        currTrash.Throw(spawnPoint.up, spitStrength);
        Destroy(spawnedTrash, 5);
    }
}
