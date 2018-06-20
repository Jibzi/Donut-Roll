using UnityEngine;

//An auditory manager based on Brackeys' tutorial; and some changes I made thereto on a personal project 
public class AudioManager : MonoBehaviour
{
    //A manager class for audio. Call a sound with FindObjectOfType<AudioManager>().Play(sound's name);
    public Sound[] sounds;

    public static AudioManager instance;
    // Use this for preinitialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //
        DontDestroyOnLoad(gameObject);  //Forbid the gameObject from being destroyed on having loaded
        //Changed the foreach loop to a for loop. Iteratively link the properties of the given sound's properties and those of its source.
        for (int iterator = 0; iterator < sounds.Length; iterator++)
        {
            sounds[iterator].source = gameObject.AddComponent<AudioSource>();
            sounds[iterator].source.clip = sounds[iterator].clip;
            sounds[iterator].source.volume = sounds[iterator].volume;
            sounds[iterator].source.pitch = sounds[iterator].pitch;
            sounds[iterator].source.loop = sounds[iterator].loop;
        }
    }
    // Use this for initialization
    void Start()
    {
        Play(sounds[0].name);
        Collectable.Collected += PlayCollectedSound;
    }

    //Delegate method to play a sound upon having collected a collectable.
    void PlayCollectedSound(object sender, System.EventArgs eventArgs)
    {
        Play(sounds[1].name);
    }


    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning(s.name + " is not a sound.");
            return;
        }
        s.source.Play();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
