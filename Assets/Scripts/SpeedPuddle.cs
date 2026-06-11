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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = other.gameObject.GetComponentInParent<PlayerController>();
            float currSpeed = playerController.getSpeed();
            StartCoroutine(playerController.speedBoost(currSpeed + speedBoost));
        }
    }

    public void Destroy()
    {
        Destroy(gameObject, spawnDuration);
    }

}
