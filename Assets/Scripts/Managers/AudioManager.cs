using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource sfxSource;
        public static AudioManager AudioInstance { get; private set; }

        public void Awake()
        {
            if (AudioInstance == null)
            {
                AudioInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void PlaySoud(AudioClip clipToPlay)
        {
            sfxSource.PlayOneShot(clipToPlay);
        }
    }
}