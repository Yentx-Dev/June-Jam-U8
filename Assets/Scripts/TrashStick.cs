using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class TrashStick : MonoBehaviour
{
    public float stickDelay;
    //public int thrustSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Rigidbody rb = (Rigidbody)GetComponent<Rigidbody>();
        //    rb.AddRelativeForce(Vector3.forward * thrustSpeed, ForceMode.Impulse);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("surface")) //Checks if collided tag is "surface"
        {
            StartCoroutine(startStickDelay());
        }

    }

    IEnumerator startStickDelay()
    {
        Debug.Log("Trigger");
        Rigidbody rb = GetComponent<Rigidbody>(); //Gets rigidbody component on current object

        yield return new WaitForSeconds(stickDelay);
        rb.isKinematic = true; //Sets rigidbody to kinematic so it will be stationary
        Destroy(gameObject, 10);
        Debug.Log($"Object delay: {stickDelay} and destroyed in 10 secondsss");
    }
}
