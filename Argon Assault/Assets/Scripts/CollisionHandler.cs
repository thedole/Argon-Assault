using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float levelLoadDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        SendMessage("OnCollisionTriggered");
    }
}
