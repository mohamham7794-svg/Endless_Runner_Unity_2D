using UnityEngine;

public class debuggingray : MonoBehaviour
{
    public Transform raycastOrigin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray =  Physics2D.Raycast(raycastOrigin.position, Vector2.down);
        Debug.Log(ray.transform.name);
        Debug.DrawRay(raycastOrigin.position,Vector2.down,Color.red);
    }
}
