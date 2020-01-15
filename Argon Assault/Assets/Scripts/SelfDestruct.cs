using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    float delayBeforeDestruction = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayBeforeDestruction);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
