using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapons : MonoBehaviour
{
    List<ParticleSystem> lazerParticles;

    // Start is called before the first frame update
    void Start()
    {
        var lazers = FindObjectsOfType<GameObject>()
            .Where(o => o.name.Contains("Lazer"));
        lazerParticles = lazers.Select(l => l.GetComponent<ParticleSystem>()).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        var fire1Down = CrossPlatformInputManager.GetButtonDown("Fire1");
        if (fire1Down)
        {
            lazerParticles.ForEach(lp => lp.Play());
        }
    }
}
