using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Koneski.Tweener;

public class TweenTest05 : MonoBehaviour
{
    //  Random swinging.
	void Start ()
    {
        transform.SwingTransform(Random.Range(1, 5), Random.Range(1, 5)).Repeat(-1).Start();
	}
}
