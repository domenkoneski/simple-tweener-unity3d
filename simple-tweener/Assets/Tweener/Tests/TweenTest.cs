using Koneski.Tweener;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        float duration = 5;

        Tween tween = FloatTween.CreateTween(duration, 
        //  Called each update with 'time' being time left.
        (time) =>
        {
            //  (Optional if needed).
            //  To normalize the time value from 0 - 1.
            //  0 means tween just started, 1 means tween is dead.
            float normalized = (1.0f - time / duration);

            //  For testing purposes lets move transform somewhere.
            Vector3 nextPosition = transform.position + Vector3.up * Mathf.Sin(time * time) * Time.deltaTime * 3;

            //  Set the next position.
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