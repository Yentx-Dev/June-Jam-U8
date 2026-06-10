using UnityEngine;

public class ThrowableTrash : MonoBehaviour
{
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
}
