using System;
using System.Collections.Generic;
using UnityEngine;

public class BallView : Part
{
    private AudioSource audioSource;

    public new void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();

        root.model.ballModel.collisionEnter += playSound;
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

    public void playSound(object sender, EventArgs args)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
