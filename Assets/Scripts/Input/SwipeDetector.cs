using UnityEngine;
using System;
using Assets.Scripts;
using System.Collections;


public enum State
{
    SwipeNotStarted,
    SwipeStarted
}

public class SwipeDetector : MonoBehaviour, IInputDetector
{
	/*
	float deltaX = Input.GetTouch().deltaPosition.x;
	float deltaY = Input.GetTouch().deltaPosition.y;
	float biggerDelta = (deltaX > deltaY) ? deltaX : deltaY;
	int direction = Mathf.Sign (biggerDelta);
	*/

    private State state = State.SwipeNotStarted;
    private Vector2 startPoint;
    private DateTime timeSwipeStarted;
    private TimeSpan maxSwipeDuration = TimeSpan.FromSeconds(1);
    private TimeSpan minSwipeDuration = TimeSpan.FromMilliseconds(100);


	public enum SwipeDirection
	{
		Up,
		Down,
		Right,
		Left
	}

	public static event Action<SwipeDirection> Swipe;
	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;

	void Update () {
		/*
		if (Input.touchCount == 0) 
			return;

		if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0){
			if (swiping == false){
				swiping = true;
				lastPosition = Input.GetTouch(0).position;
				return;
			}
			else{
				if (!eventSent) {
					if (Swipe != null) {
						Vector2 direction = Input.GetTouch(0).position - lastPosition;

						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							if (direction.x > 0) 
								Swipe(SwipeDirection.Right);
							else
								Swipe(SwipeDirection.Left);
						}
						else{
							if (direction.y > 0)
								Swipe(SwipeDirection.Up);
							else
								Swipe(SwipeDirection.Down);
						}

						eventSent = true;
					}
				}
			}
		}
		else{
			swiping = false;
			eventSent = false;
		}
		*/
	}

    public InputDirection? DetectInputDirection()
    {
        if (state == State.SwipeNotStarted)
        {
            //Touch touch = Input.GetTouch(0);
            //if(touch.phase == TouchPhase.Began)
            //{
            //    // start of swipe
            //}
            //if (touch.phase == TouchPhase.Ended)
            //{
            //    // End of swipe
            //}
            

            if (Input.GetMouseButtonDown(0))
            {
                timeSwipeStarted = DateTime.Now;
                state = State.SwipeStarted;
                startPoint = Input.mousePosition;
            }
        }
        else if (state == State.SwipeStarted)
        {
			/*if (Input.GetTouch)
			{
				TimeSpan timeDifference = DateTime.Now - timeSwipeStarted;
				if (timeDifference <= maxSwipeDuration && timeDifference >= minSwipeDuration)
				{
					Vector2  = Input.mousePosition;
					Vector2 differenceVector = mousePosition - startPoint;
					float angle = Vector2.Angle(differenceVector, Vector2.right);
					Vector3 cross = Vector3.Cross(differenceVector, Vector2.right);

					if (cross.z > 0)
						angle = 360 - angle;

					state = State.SwipeNotStarted;

					if ((angle >= 315 && angle < 360) || (angle >= 0 && angle <= 45))
						return InputDirection.Right;
					else if (angle > 45 && angle <= 135)
						return InputDirection.Top;
					else if (angle > 135 && angle <= 225)
						return InputDirection.Left;
					else
						return InputDirection.Bottom;
				} */
			}
            if (Input.GetMouseButtonUp(0))
            {
                TimeSpan timeDifference = DateTime.Now - timeSwipeStarted;
                if (timeDifference <= maxSwipeDuration && timeDifference >= minSwipeDuration)
                {
                    Vector2 mousePosition = Input.mousePosition;
                    Vector2 differenceVector = mousePosition - startPoint;
                    float angle = Vector2.Angle(differenceVector, Vector2.right);
                    Vector3 cross = Vector3.Cross(differenceVector, Vector2.right);

                    if (cross.z > 0)
                        angle = 360 - angle;

                    state = State.SwipeNotStarted;

                    if ((angle >= 315 && angle < 360) || (angle >= 0 && angle <= 45))
                        return InputDirection.Right;
                    else if (angle > 45 && angle <= 135)
                        return InputDirection.Top;
                    else if (angle > 135 && angle <= 225)
                        return InputDirection.Left;
                    else
                        return InputDirection.Bottom;
                }
            }
		return null;
        }
      //  
    }
	
/*
using System.Collections;

public class MiniGestureRecognizer : MonoBehaviour {

	

	public static event Action<SwipeDirection> Swipe;
	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;

	void Update () {
		if (Input.touchCount == 0) 
			return;

		if (Input.GetTouch(0).deltaPosition.sqrMagnitude != 0){
			if (swiping == false){
				swiping = true;
				lastPosition = Input.GetTouch(0).position;
				return;
			}
			else{
				if (!eventSent) {
					if (Swipe != null) {
						Vector2 direction = Input.GetTouch(0).position - lastPosition;

						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							if (direction.x > 0) 
								Swipe(SwipeDirection.Right);
							else
								Swipe(SwipeDirection.Left);
						}
						else{
							if (direction.y > 0)
								Swipe(SwipeDirection.Up);
							else
								Swipe(SwipeDirection.Down);
						}

						eventSent = true;
					}
				}
			}
		}
		else{
			swiping = false;
			eventSent = false;
		}
	}
}
*/