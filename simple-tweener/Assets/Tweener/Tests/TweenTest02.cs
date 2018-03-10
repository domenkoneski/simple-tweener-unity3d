using Koneski.Tweener;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest02 : MonoBehaviour
{
    void Start()
    {
        float duration = 10;

        float startScale = transform.localScale.x;
        Vector3 startPosition = transform.position;

        Tween tween = FloatTween.CreateTween(duration, 
        //  Called each update with 'time' being time left.
        (time) =>
        {
            //  Rotate the transform around startPosition.
            Vector3 nextPosition = startPosition + Vector3.up * Mathf.Sin(5 * time) + Vector3.left * Mathf.Cos(5 * time);
            transform.position = nextPosition;
        }, 
        //  Called at the end of the tween. (Tween dies).
        () =>
        {
            Debug.Log("Tween has ended!");
        });

        //  Don't forget to start me.
        tween.Start();
	}
}