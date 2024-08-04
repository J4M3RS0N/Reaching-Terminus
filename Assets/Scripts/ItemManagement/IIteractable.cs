using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIteractable
{

    void Interact(Transform interactorTransform);
    string GetInteractText();
    Transform GetTransform();

}
