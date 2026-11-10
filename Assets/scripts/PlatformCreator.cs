using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformprefab;
    [SerializeField] Transform referensepoint;
    [SerializeField] GameObject lastCreatedPlatform;
    [SerializeField] float spaceBetweenPlatforms=2;
    float lastPlatfromWidth;


    void Update()
    {
        if (lastCreatedPlatform.transform.position.x < referensepoint.position.x )
        {
            Vector3 targetCreationPoint = new Vector3(referensepoint.position.x + lastPlatfromWidth + 
            spaceBetweenPlatforms, 0,0);
            int randomPlatform = Random.Range(0,platformprefab.Length);
            lastCreatedPlatform = Instantiate(platformprefab[randomPlatform],targetCreationPoint,Quaternion.identity);
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatfromWidth = collider.bounds.size.x;
        }
    }
}