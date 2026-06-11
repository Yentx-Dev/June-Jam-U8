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
        audioSource = GetComponent<AudioSource>();
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(splatClip, 1f);
        //rb.isKinematic = true; //Sets rigidbody to kinematic so it will be stationary
        StartCoroutine(startStickDelay());
    }

    IEnumerator startStickDelay()
    {
        Debug.Log("Trigger");

        yield return new WaitForSeconds(destroyDelay);
        
        Destroy(gameObject);
        Debug.Log($"Object delay: {destroyDelay} and destroyed in 10 secondsss");
    }
}
