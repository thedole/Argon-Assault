using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    [SerializeField]
    Transform spawnParent;

    [Tooltip("The value for this enemy when killed")]
    [SerializeField]
    int score = 10;

    [Tooltip("The number of hits needed to kill this enemy")]
    [SerializeField]
    int hitsNeeded = 3;

    [SerializeField]
    GameObject scoreBoard;
    ScoreBoard scoreBoardScript;

    bool isAlive = true;



    public void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoardScript = scoreBoard.GetComponent<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        var particleCollider = gameObject.AddComponent<BoxCollider>();
        particleCollider.isTrigger = false;
    }

    public void OnParticleCollision(GameObject other)
    {
        if (!isAlive)
        {
            return;
        }

        processHit();

    }

    private void processHit()
    {
        hitsNeeded--;

        if (hitsNeeded <= 0)
        {
            explode();
        }
    }

    private void explode()
    {
        scoreBoardScript.AddScore(score);
        isAlive = false;
        explosion = Instantiate(explosion, transform.position, transform.rotation);
        explosion.transform.parent = spawnParent;
        Destroy(gameObject);
    }
}
