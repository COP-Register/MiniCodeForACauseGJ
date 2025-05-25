using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlaySound(AudioClip clip, Transform spawnTransform, float volume, float clipLength = 1.0f)
    {
        AudioSource soundObject = Instantiate(audioSource, spawnTransform.position, Quaternion.identity);
        
        soundObject.clip = clip;
        soundObject.volume = volume;
        soundObject.Play();

        clipLength *= soundObject.clip.length;
        
        Destroy(soundObject.gameObject, clipLength);
    }
    
}
   
