using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfoHolder : MonoBehaviour
{
    public List<Light> lightTargets;
    public List<Transform> transformTargets;
    public List<AudioClip> audioTargets;
    public enum scaryEventTier {Low, Medium, High};

    void Start()
    {

    }
}
