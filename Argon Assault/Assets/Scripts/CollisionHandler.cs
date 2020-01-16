using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    float levelLoadDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.Friendly)
        {
            return;
        }

        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnCollisionTriggered");
        var explosion = transform.Find("Explosion")?.gameObject;

        explosion?.SetActive(true);

        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        var activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(levelLoadDelay);

        SceneManager.LoadScene(activeSceneIndex);
    }
}
