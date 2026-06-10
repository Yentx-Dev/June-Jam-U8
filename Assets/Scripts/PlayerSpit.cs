using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpit : MonoBehaviour
{
    public int spitStrength;
    public float minSize =0.5f;
    public int maxSpits = 5;
    public float maxSize =1f; // set to what the player is originally on start
    private float sizeDelta;
    private InputAction spitAction;
    public GameObject trashObject;
    private ThrowableTrash currTrash;
    public Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spitAction = InputSystem.actions.FindAction("Spit");
        //maxSize = GetComponent<Transform>().localScale.x;
        sizeDelta = (maxSize - minSize) / (maxSpits);
        spitAction.started += context =>
        {
            Transform playerTransform = GetComponent<Transform>();
            float currSize = playerTransform.localScale.x;
            if (currSize <= minSize) { return; } // Don't spit if at min size
            spitTrash();
            float newSize = Mathf.Max(minSize, currSize - sizeDelta);
            playerTransform.localScale = new Vector3(newSize, newSize, newSize);
            //sphereCollider.radius = newSize / maxSpits * sCollider ;
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

    private void eatTrash(GameObject trash)
    {
        Transform playerTransform = GetComponent<Transform>(); //access transform component
        float currSize = playerTransform.localScale.x; //store current size of trashbag

        if (currSize >= maxSize) { return; } //stops code if current size is equals to maxSize

        float newSize = Mathf.Min(maxSize, currSize + sizeDelta);
        playerTransform.localScale = new Vector3(newSize, newSize, newSize);

        Destroy(trash);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            Debug.Log("Yum");
            eatTrash(other.gameObject);
        }
    }
}
