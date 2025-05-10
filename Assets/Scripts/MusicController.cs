using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] themes;
    private AudioSource source;
    private int currentThemeIndex = 0;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!source.isPlaying)
        {
            currentThemeIndex++;
            source.PlayOneShot(themes[currentThemeIndex]);
        }
    }
}
