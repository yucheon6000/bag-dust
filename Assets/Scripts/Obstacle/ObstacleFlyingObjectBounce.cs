using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFlyingObjectBounce : ObstacleFlyingObject
{
    [Header("Bounce")]
    [SerializeField]
    private float bounceColliderDisableTimeAtFirst = 3;
    [SerializeField]
    private LayerMask targetBounceLayerMask;
    [SerializeField]
    private int targetBounceCount = 3;
    private int currentBounceCount = 0;
    [SerializeField]
    private Collider bounceCollider;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip bounceAudioClip;

    private void Start()
    {
        bounceCollider.enabled = false;
    }

    protected override void AddForce()
    {
        base.AddForce();
        Invoke(nameof(EnableBounceCollider), bounceColliderDisableTimeAtFirst);
    }

    private void EnableBounceCollider()
    {
        bounceCollider.enabled = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (((1 << other.gameObject.layer) & targetBounceLayerMask) == 0) return;
        if (currentBounceCount != 0) return;

        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (((1 << other.gameObject.layer) & targetBounceLayerMask) == 0) return;

        currentBounceCount++;

        if (currentBounceCount >= targetBounceCount)
            bounceCollider.enabled = false;

        audioSource?.PlayOneShot(bounceAudioClip);
    }
}
