using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ObjectInfoHolder : MonoBehaviour
{
    public List<Light> lightTargets = new List<Light>();
    public List<Transform> transformTargets = new List<Transform>();
    public List<AudioSource> audioTargets = new List<AudioSource>();
    public scaryEventTier ObjectTier;

    // void Start()
    // {
    //     for(int i = 0; i < this.transform.childCount; i++){
    //         transformTargets.Add(this.transform.GetChild(i).transform);
    //         lightTargets.Add(this.transform.GetChild(i).GetChild(0).GetComponent<Light>());
    //         audioTargets.Add(this.transform.GetChild(i).GetChild(1).GetComponent<AudioSource>());
    //     }
    // }ばばばばばぱ
}
