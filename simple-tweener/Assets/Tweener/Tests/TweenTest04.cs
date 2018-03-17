using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Koneski.Tweener;

public class TweenTest04 : MonoBehaviour
{
	void Start ()
    {
        TransformTween.SwingTransform(transform, 2, 2).Repeat(-1).Start();
	}
}
