using UnityEngine;

public class MusicManager : MonoBehaviour 
{
    // sound file clip 1
    public AudioClip clipMedieval;

    // sound file clip 2
    public AudioClip clipArcade;

    // audio source component 1
    private AudioSource audioSourceMedieval;

    // audio source component 2
    private AudioSource audioSourceArcade;

    /// <summary>
    /// create gameobjects containing audio source components linked to the 2 sound clip files
    /// </summary>
    void Awake()
    {
        audioSourceMedieval = CreateAudioSource(clipMedieval, true);
        audioSourceArcade = CreateAudioSource(clipArcade, false);
    }

    /// <summary>
    /// create a game object with an audio source component
    /// linked to the provided audio clip
    /// </summary>
    /// <returns>The audio source.</returns>
    /// <param name="audioClip">Audio clip the audio source component is to be linked to</param>
    /// <param name="startPlayingImmediately">If set to <c>true</c> start playing immediately.</param>
    private AudioSource CreateAudioSource(AudioClip audioClip, bool startPlayingImmediately)
    {
        // create new empty GameObject
        GameObject audioSourceGO = new GameObject();

        // position new GO in same posution as parent to this scripted component
        audioSourceGO.transform.position = transform.position;

        // add AudioSource component
        AudioSource newAudioSource = audioSourceGO.AddComponent<AudioSource>() as AudioSource;

        // associate clip with AudioSource
        newAudioSource.clip = audioClip;

        // start playing as soon as created (if parameter was 'true')
        if(startPlayingImmediately)
            newAudioSource.Play();

        // use next line if you want this clip to self-destroy when clip finishes playing
        //        Destroy(instance.gameObject, clip.length);
        return newAudioSource;
    }


    // every frame pause/resume music clip if correct key is pressed
    void Update()
    {
        // Music 1
        // if already started, resume playing
        // else start playing
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (audioSourceMedieval.time > 0)
                audioSourceMedieval.UnPause();
            else
                audioSourceMedieval.Play();
        }

        // pause playing
        if (Input.GetKey(KeyCode.LeftArrow))
            audioSourceMedieval.Pause();
        
        // Music 2
        // if already started, resume playing
        // else start playing
        if (Input.GetKey(KeyCode.UpArrow)){
            if (audioSourceArcade.time > 0)
                audioSourceArcade.UnPause();
            else
                audioSourceArcade.Play();            
        }

        // pause playing
        if (Input.GetKey(KeyCode.DownArrow))
            audioSourceArcade.Pause();

    }
}