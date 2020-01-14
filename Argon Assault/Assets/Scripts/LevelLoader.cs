using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private int nextLevelDelay = 6;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NextLevel());
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(nextLevelDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
