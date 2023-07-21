using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        transform.localScale = Vector3.one * 10;
    }
}
