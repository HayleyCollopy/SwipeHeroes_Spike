using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public float minSwipeDistance = 25.0f; //pixels

    Vector2 starttouch;

    Vector2 endtouch;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                starttouch = touch.position;
                endtouch = touch.position;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                endtouch = touch.position;
                CheckSwipe();
            }
        }
    }

    void CheckSwipe()
    {
        float vdist = Mathf.Abs(endtouch.y - starttouch.y);
        float hdist = Mathf.Abs(endtouch.x - starttouch.x);
        bool isVerticalSwipe = (vdist > hdist);
        bool swipeDistMet = ((vdist > minSwipeDistance) || (hdist > minSwipeDistance));
        if (swipeDistMet)
        {
            if (isVerticalSwipe)
            {
                if (endtouch.y > starttouch.y)
                {
                    animator.Play("Base Layer.SpikeUp");
                }
                else
                {
                    animator.Play("Base Layer.SpikeDown");
                }
            }
            else
            {
                if (endtouch.x > starttouch.x)
                {
                    animator.Play("Base Layer.SpikeRight");
                }
                else
                {
                    animator.Play("Base Layer.SpikeLeft");
                }
            }
        }
    }
}
