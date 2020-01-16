using Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapons : MonoBehaviour
{
    List<ParticleSystem> lazerParticles;
    [SerializeField]
    AudioClip lazerSound;

    FadingAudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        var lazers = FindObjectsOfType<GameObject>()
            .Where(o => o.name.Contains("Lazer"));
        lazerParticles = lazers.Select(l => l.GetComponent<ParticleSystem>()).ToList();
        audioSource = new FadingAudioSource(GetComponent<AudioSource>());
    }

    // Update is called once per frame
    void Update()
    {
        var fire1Down = CrossPlatformInputManager.GetButtonDown("Fire1");
        if (fire1Down)
        {
            lazerParticles.ForEach(lp => lp.Play());
            audioSource.PlayOneShot(lazerSound);
        }

        var fire1up = CrossPlatformInputManager.GetButtonUp("Fire1");
        if (fire1up && audioSource.IsPlaying)
        {
            audioSource.FadeOut();
        }
    }
}
