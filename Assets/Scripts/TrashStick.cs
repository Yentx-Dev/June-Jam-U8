using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class TrashStick : MonoBehaviour
{
    public float destroyDelay;
    Rigidbody rb;

    public AudioSource audioSource;
    public AudioClip splatClip;
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

        yield return new WaitForSeconds(destroyDelay);
        audioSource.PlayOneShot(splatClip, 1f);
        rb.isKinematic = true; //Sets rigidbody to kinematic so it will be stationary
        Destroy(gameObject);
        Debug.Log($"Object delay: {destroyDelay} and destroyed in 10 secondsss");
    }
}
