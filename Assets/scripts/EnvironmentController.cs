using System.Collections;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    [SerializeField] GameObject[] EnvironmentElement;
    [SerializeField] Transform  ElementRefPoint;
    int randomElement;

    void Start()
    {
        StartCoroutine(CreateEnvironmentElement());
        
    }
    IEnumerator CreateEnvironmentElement()
    {
        while (true)
        {
            if (EnvironmentElement.Length > 0)
            {
                randomElement = Random.Range(0, EnvironmentElement.Length);
                Instantiate(EnvironmentElement[randomElement], ElementRefPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("EnvironmentController: no prefabs assigned.");
                yield break;
            }
            yield return new WaitForSeconds(Random.Range(3, 7));
        }
    }


    void Update()
    {
        
    }
}
