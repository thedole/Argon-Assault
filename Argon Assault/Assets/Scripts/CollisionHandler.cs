using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float levelLoadDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnCollisionTriggered");
        var explosion = transform.Find("Explosion")?.gameObject;
        explosion.SetActive(true);
    }
}
