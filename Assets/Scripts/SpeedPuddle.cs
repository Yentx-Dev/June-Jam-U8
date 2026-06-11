using System.Collections;
using UnityEngine;

public class SpeedPuddle : MonoBehaviour
{
    [SerializeField] private int speedBoost;
    [SerializeField] private float spawnDuration = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponentInParent<PlayerController>();
            float currSpeed = playerController.getSpeed();
            StartCoroutine(playerController.speedBoost(currSpeed + speedBoost));
        }
    }

    public void Destroy()
    {
        Destroy(gameObject, spawnDuration);
    }

}
