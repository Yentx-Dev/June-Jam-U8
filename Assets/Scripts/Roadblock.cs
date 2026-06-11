using UnityEngine;

public class Roadblock : MonoBehaviour
{
    Rigidbody rb;
    float requiredMass = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerSpit playerSpit = collision.gameObject.GetComponent<PlayerSpit>();

            if (playerSpit != null && playerSpit.currentMass >= requiredMass)
            {
                rb.isKinematic = false;
                Debug.Log(playerSpit.currentMass);
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = true;
        }
    }
}
