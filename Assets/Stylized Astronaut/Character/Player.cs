using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

    GameControl GameControl;
    Complete CompleteFinish;

    private bool CompleteIsActive;
    public float TurnS;
    [Header("Move")]
    private bool Forward;
    private bool Back;
    private bool Left;
    private bool Right;
  
    public float speed;
    public float turnSpeed = 400.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;
    public int CharacterNumber;
    public bool CountrIsActice;
    Rigidbody rb;
    private Animator anim;
    private CharacterController controller;

   

    void Start()
    {

        TurnS = 2.5F;
        speed = 3F;
        rb= gameObject.GetComponent<Rigidbody>();
        CountrIsActice = false;
        GameControl = GameObject.FindWithTag("GameControl").GetComponent<GameControl>();
        CompleteIsActive = true;
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
        CompleteFinish =GameObject.FindWithTag("Complete").GetComponent<Complete>();
     



        Forward = false;
        Back = false;
        Left = false;
        Right = false;

    }
    void Update()
    {
       
        if (Input.GetKey("w")|| Input.GetKey("s")|| Forward == true || Back == true || Left == true || Right == true)
        {
            anim.SetInteger("AnimationPar", 1);
        }
    
        else
        {
            anim.SetInteger("AnimationPar", 0);
        }


        if (controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }

        float turn = Input.GetAxis("Horizontal");
        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
       // moveDirection.y -= gravity * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {



        if (other.gameObject.CompareTag("StartPoint"))
        {
            CountrIsActice = true;
            GameControl.zamanlayici = true;
            
        }


        if (other.transform.CompareTag("Complete"))
        {
          
            StartCoroutine(Complete());
          
        }

        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            if (other.transform.CompareTag("Complete"))
            {
                if (other.gameObject.GetComponent<Complete>().Level >= PlayerPrefs.GetInt("Level"))
                {
                    PlayerPrefs.SetInt("Level", other.gameObject.GetComponent<Complete>().Level);
                }
            }
            
        }


      

        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            if (other.transform.CompareTag("Complete"))
            {
                if (other.gameObject.GetComponent<Complete>().Level >= PlayerPrefs.GetInt("LevelMiddle"))
                {
                    PlayerPrefs.SetInt("LevelMiddle", other.gameObject.GetComponent<Complete>().Level);
                }
            }
          

        }


        if (PlayerPrefs.GetInt("Difficulty") ==3)
        {
            if (other.transform.CompareTag("Complete"))
            {
                if (other.gameObject.GetComponent<Complete>().Level >= PlayerPrefs.GetInt("LevelHard"))
                {
                    PlayerPrefs.SetInt("LevelHard", other.gameObject.GetComponent<Complete>().Level);
                }
            }
         

        }
      


    }
    IEnumerator Complete()
    {
        yield return new WaitForSeconds(.23f);
        CompleteIsActive = false;
        yield return new WaitForSeconds(0);
        
        GameControl.Win();

       


    }

    
    void Move()
    {

        if (Forward == true&& CompleteIsActive==true)
        {
      
            Forward = true;
            // transform.Translate(new Vector3(0, 0, moveDirection.z+1) * speed * Time.deltaTime);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);,
             moveDirection = transform.forward*speed;

            
        }
        else
        {
            Forward = false;
            anim.SetInteger("AnimationPar", 0);

        }

        if (Left == true)
        {
      
            Left = true;
            transform.Rotate(0, -TurnS, 0);
       
           
        }
        else
        {
            Left = false;
            anim.SetInteger("AnimationPar", 0);

        }


        if (Back == true && CompleteIsActive == true)
        {
          
            Back = true;
            //transform.Translate(Vector3.back * speed * Time.deltaTime);
            moveDirection = transform.forward * -speed;

        }
        else
        {
            Back = false;
            anim.SetInteger("AnimationPar", 0);

        }

        if (Right == true)
        {
     
            Right = true;
            transform.Rotate(0, TurnS, 0);


        }
        else
        {
            Right = false;
            anim.SetInteger("AnimationPar", 0);

        }

    }
    private void FixedUpdate()
    {
        

        Move();
      
    }
    public void ForwardMoveDown()
    {
        Forward = true;
        anim.SetInteger("AnimationPar", 1);
      
    }
    public void ForwardMoveUp()
    {
        Forward = false;
       
    }
    public void BackMoveDown()
    {
        Back = true;
      
    }
    public void BackMoveUp()
    {
        Back = false;
        
    }
    public void LeftMoveDown()
    {
        Left = true;
      

    }
    public void LeftMoveUp()
    {
        Left = false;
      
    }
    public void RightMoveDown()
    {
        Right = true;
     
    }
    public void RightMoveUp()
    {
        Right = false;
       
    }
}
