using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallView : Part
{
    private AudioSource audioSource;

    public new void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (root.model.ballModel == null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = root.model.ballModel.transform.position;
    }

    public void playSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
