using UnityEngine;

public class PlaySoundOnBounce : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}
