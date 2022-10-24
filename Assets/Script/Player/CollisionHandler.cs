using UnityEngine;
using UnityEngine.SceneManagement;

// To handle the player's collisions
public class CollisionHandler : MonoBehaviour
{
    bool isPlaying = false;
    
    AudioSource audioSource;

    float crashDelay = 0.75f;
    float finishDelay = 2f;
    float crashSoundVolume = 0.25f;

    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip finish;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem finishParticle;

    Rigidbody rb;
 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Control to not enter sequences more than one time
        if (isPlaying)
        {
            return;
        }
        switch (collision.gameObject.tag){

            case "Obstacle":
                crashSequence();
                break;

            case "Finish":
                nextLevelSequence();
                break;
        }

    }

    void crashSequence()
    {
        // Control to not enter sequences more than one time
        isPlaying = true;
        // Stoping the audio of engine thrust. Because crash sound mixes with engine sound otherwise.
        audioSource.Stop();
        // Give a better feeling to player when he/she crashes and to neglect the function audioSource.Stop() comes from Movement script
        GetComponent<Movement>().enabled = false;
        crashParticle.Play();
        audioSource.PlayOneShot(crash, crashSoundVolume);
        // Invokes reloadLevel() function after 0.75s
        Invoke("reloadLevel", crashDelay);
        
    }

    void reloadLevel()
    {
        // Gets the current index
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void nextLevelSequence()
    {
        // Control to not enter sequences more than one time
        isPlaying = true;
        // Stoping the audio of engine thrust. Because crash sound mixes with next level sound otherwise.
        audioSource.Stop();
        // Give a better feeling to player when he/she crashes and to neglect the function audioSource.Stop() comes from Movement script
        GetComponent<Movement>().enabled = false;
        finishParticle.Play();
        audioSource.PlayOneShot(finish);
        // Freezing the position and rotation of rocket to give better visual to player
        freezeRocketMovement();
        // Invokes nextLevel() function after 2s
        Invoke("nextLevel", finishDelay);
    }

    void nextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if(nextIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextIndex = 0;
        }
        SceneManager.LoadScene(nextIndex);
    }

    void freezeRocketMovement()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }


    

}
