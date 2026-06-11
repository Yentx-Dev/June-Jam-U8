using Unity.VisualScripting;
using UnityEngine;

public class ThrowableTrash : MonoBehaviour
{
    private bool landed = false;
    [SerializeField] private GameObject speedPuddle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Takes direction vector and throw strength
    public void Throw(Vector3 direction, int strength)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction.normalized * strength);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("surface") && landed == false)
        {
            landed = true;
            Debug.Log("Throwable landed");
            ContactPoint contactPoint = collision.GetContact(0);
            Quaternion contactObjectRotation = contactPoint.otherCollider.transform.rotation;
            GameObject spawnedPuddle = Instantiate(speedPuddle, contactPoint.point, contactObjectRotation);
            Debug.Log($"Spawned puddle at {Time.time}");
            spawnedPuddle.GetComponent<SpeedPuddle>().Destroy();
        }
    }
}
