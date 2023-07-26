using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grow : MonoBehaviour, IInteractable
{
    [SerializeField] float growRate;
    [SerializeField] float maxSize;
    [SerializeField] ParticleSystem popParticles;

    bool growing;
    float previousScale;
    public void Interact()
    {
        if (transform.localScale.x < maxSize)
        {
            transform.localScale *= 1 + growRate / 100;
        }
        else
        {
            var particles = Instantiate(popParticles, transform);
            particles.transform.parent = null;
            Destroy(gameObject);
        }
    }

    void Update()
    {

        if (transform.transform.localScale.x > previousScale) 
        { 
            growing = true;

            previousScale = transform.localScale.x;
        }
        else
        {
            growing = false;
            previousScale = transform.localScale.x;
        }


        Debug.Log("Growing is: " + growing);
    }
}
