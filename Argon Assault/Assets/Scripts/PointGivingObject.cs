using System.Collections;
using UnityEngine;

public class PointGivingObject : MonoBehaviour
{
    [SerializeField]
    GameObject scoreBoard;
    ScoreBoard scoreBoardScript;

    [SerializeField]
    int score;

    GameObject pointSound;

    public void Start()
    {
        scoreBoardScript = scoreBoard.GetComponent<ScoreBoard>();
        pointSound = transform.Find("PointSound")?.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (pointSound != null)
        {
            pointSound.SetActive(true);
        }
        scoreBoardScript.AddScore(score);
        StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
