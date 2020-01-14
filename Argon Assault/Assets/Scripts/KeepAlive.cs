using UnityEngine;

public class KeepAlive : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
    }
}
