using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public float Speed;
    Animator GetAnimator;
    public Camera Cam;
    
  
    private bool Forward;
    private bool Back;
    private bool Left;
    private bool Right;
    private Image ForwardButton;
    private Image BackButton;
    private Image LeftButton;
    private Image RightButton;
    void Start()
    {
        ForwardButton = GameObject.FindWithTag("Forward").GetComponent<Image>();
        BackButton = GameObject.FindWithTag("Back").GetComponent<Image>();
        LeftButton = GameObject.FindWithTag("Left").GetComponent<Image>();
        RightButton = GameObject.FindWithTag("Right").GetComponent<Image>();
        Forward = false;
        Back = false;
        Left = false;
        Right = false;
        GetAnimator = GetComponent<Animator>();
    }

    void Move()
    {

        if (Forward==true)
        {
            Forward = true;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            GetAnimator.SetInteger("AnimationPar", 1);
            transform.Translate(new Vector3(0, 0, 1f) * Speed * Time.deltaTime);

        }
        else
        {
            Forward = false;
            GetAnimator.SetBool("walk", false);

        }

        if (Left==true)
        {
            Left = true;
            transform.Translate(new Vector3(0, 0, 1f) * Speed * Time.deltaTime);
            //  GetAnimator.SetInteger("AnimationPar", 1);
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
        else
        {
            Left = false;
            GetAnimator.SetBool("walk", false);

        }


        if (Back==true)
        {
            Back = true;
            transform.Translate(new Vector3(0, 0, 1f) * Speed * Time.deltaTime);
            GetAnimator.SetInteger("AnimationPar", 1);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            Back = false;
            GetAnimator.SetBool("walk", false);

        }

        if (Right==true)
        {
            Right = true;
            transform.Translate(new Vector3(0, 0, 1f) * Speed * Time.deltaTime);
            //GetAnimator.SetInteger("AnimationPar", 1);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            Right = false;
            GetAnimator.SetBool("walk", false);

        }

    }
    private void FixedUpdate()
    {
        Move();
        if (Forward || Back || Left || Right)
        {
            GetAnimator.SetBool("walk", true);
        }
    }

    public void ForwardMoveDown()
    {
        Forward = true;

        BackButton.raycastTarget = false;
        LeftButton.raycastTarget = false;
        RightButton.raycastTarget = false;

    }

    public void ForwardMoveUp()
    {
        Forward = false;
        BackButton.raycastTarget = true;
        LeftButton.raycastTarget = true;
        RightButton.raycastTarget = true;
    }

    public void BackMoveDown()
    {
        Back = true;
        ForwardButton.raycastTarget = false;
        LeftButton.raycastTarget = false;
        RightButton.raycastTarget = false;
    }
    public void BackMoveUp()
    {
        Back = false;
        ForwardButton.raycastTarget = true;
        LeftButton.raycastTarget = true;
        RightButton.raycastTarget = true;
    }


    public void LeftMoveDown()
    {
        Left = true;
        ForwardButton.raycastTarget = false;
        BackButton.raycastTarget = false;
        RightButton.raycastTarget = false;

    }
    public void LeftMoveUp()
    {
        Left = false;
        ForwardButton.raycastTarget = true;
        BackButton.raycastTarget = true;
        RightButton.raycastTarget = true;
    }

    public void RightMoveDown()
    {
        Right = true;
        ForwardButton.raycastTarget = false;
        BackButton.raycastTarget = false;
        LeftButton.raycastTarget = false;
    }
    public void RightMoveUp()
    {
        Right = false;
        ForwardButton.raycastTarget = true;
        BackButton.raycastTarget = true;
        LeftButton.raycastTarget = true;
    }
}
