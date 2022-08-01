using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Stack<Command> history; // last in first out
    public SelectColor sc;

    Vector2 pressPos = Vector2.zero;
    Vector2 releasePressPos = Vector2.zero;
    Vector2 currentSwipe = Vector2.zero;

    private void Start()
    {
        history = new Stack<Command>();
    }

    private void ExecuteCommand(Command cmd)
    {
        cmd.Execute();
        history.Push(cmd);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeRight())
        {
            sc.CurrentColor++;
            SelectCommand cmd = new SelectCommand(sc);
            ExecuteCommand(cmd);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeLeft())
        {
            sc.CurrentColor--;
            SelectCommand cmd = new SelectCommand(sc);
            ExecuteCommand(cmd);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Tap())
        {
            PlayTurnCommand cmd = new PlayTurnCommand(sc);
            ExecuteCommand(cmd);
        }

        if (Input.GetKeyDown(KeyCode.Z) && history.Count > 0)
        {
            Command undoCommand = history.Pop();
            undoCommand.Undo();
        }
    }

    private bool Tap()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.fingerId == 0)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    if (currentSwipe.magnitude == 0)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool SwipeRight()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                pressPos = new Vector2(touch.position.x, touch.position.y);

            if (touch.phase == TouchPhase.Ended)
            {
                releasePressPos = new Vector2(touch.position.x, touch.position.y);

                currentSwipe = new Vector3(releasePressPos.x - pressPos.x, releasePressPos.y - pressPos.y);
                currentSwipe.Normalize();

                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    return true;
                }
                else
                {
                    touch.phase = TouchPhase.Stationary;
                }
            }
        }

        return false;
    }
    private bool SwipeLeft()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                pressPos = new Vector2(touch.position.x, touch.position.y);

            if (touch.phase == TouchPhase.Ended)
            {
                releasePressPos = new Vector2(touch.position.x, touch.position.y);

                currentSwipe = new Vector3(releasePressPos.x - pressPos.x, releasePressPos.y - pressPos.y);
                currentSwipe.Normalize();

                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    return true;
                }
                else
                {
                    touch.phase = TouchPhase.Stationary;
                    return false;
                }
            }
        }

        return false;
    }
}