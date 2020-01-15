using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    bool isAlive = true;
    
    public void OnParticleCollision(GameObject other)
    {
        if (!isAlive)
        {
            return;
        }

        explode();
    }

    private void explode()
    {
        isAlive = false;
        explosion = Instantiate(explosion, transform.position, transform.rotation);
        explosion.SetActive(true);

        gameObject.SetActive(false);
    }
}
