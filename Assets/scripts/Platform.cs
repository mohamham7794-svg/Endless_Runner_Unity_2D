using UnityEngine;

public class Platform : MonoBehaviour

{
    public float speed = 5f;
    
    void Update()
    {
        transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
        if (transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
