using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Koneski.Tweener;

public class TweenTest03 : MonoBehaviour
{
	void Start ()
    {
        transform.TweenPosition(transform.position + Vector3.left * 5, 1.5f, () =>
        {
            transform.TweenPosition(transform.position + Vector3.right * 5, 1.5f).Start();
        }).Start();
	}
}