using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 newPos;
    public GameObject _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = _player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position;
        newPos.x = _player.transform.position.x - offset.x;
        transform.position = _player.transform.position - offset;
    }
}
