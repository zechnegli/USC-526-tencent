using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using TMPro;
using UnityEngine.SceneManagement;
using System;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;
        public float timeRemaining;
        public bool timerIsRunning = false;
        public TMP_Text timeText;
        public int expectCoins = 300;
        public bool sendTime = false;

       // public TMP_Text usingTimeText;
       // public float timeUsed;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/
        public Collider2D collider2d;
        /*internal new*/
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;


        public GameObject GameOver;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }
        protected override void Start()
        {
            timerIsRunning = true;
            print("player start");
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
            }
            else
            {
                move.x = 0;
            }



            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                    /*
                    timeUsed += Time.deltaTime;
                    DisplayTime2(timeUsed);
                    */
                    if(CoinCounterScript.instance.amount >= expectCoins && sendTime == false)
                    {
                        TimeDataCollection.controller.Send(timePeriod(timeText.text));
                        Ending.controller.Send("Succeess");
                        sendTime = true;
                        //load the success page when player collect expectCoins amount of coins
                        Scene currentScene = SceneManager.GetActiveScene();
                        string sceneName = currentScene.name;

                        

                        if (sceneName == "Level1_Scene")
                        {

                            SceneManager.LoadScene("Level1CompletedMenu");
                        }
                        else if (sceneName == "Level2_Scene")
                        {
                            SceneManager.LoadScene("Level2CompletedMenu");
                           
                        }
                        else
                        {
                            SceneManager.LoadScene("Level3CompletedMenu");
                          
                        }
                        SceneManager.UnloadScene(sceneName);

                        // TimeDataCollection.controller.Send(timePeriod(timeText.text));

                        // send ingredients data to collect when success
                        var tempgameObject1 = new GameObject();
                        Sendtogoogle sg = tempgameObject1.AddComponent<Sendtogoogle>();
                        sg.Send();

                        // send level1-level2 data
                        var sg_l = GameObject.Find("EventSystem").GetComponent<Sendtogoogle_level>();
                        if(sg_l != null)
                        {
                            sg_l.Send_burger();
                        }




                    }


                }
                else
                {

                    timeRemaining = 0;
                    timerIsRunning = false;
                    
                    if(CoinCounterScript.instance.amount<300)
                    {
                        Time.timeScale = 0f;
                        DeathReason.controller.Send("Time Out");
                        Ending.controller.Send("Fail");

                        // send ingredients data to collect when time out
                        var tempgameObject = new GameObject();
                        Sendtogoogle sg = tempgameObject.AddComponent<Sendtogoogle>();
                        sg.Send();

                        // send level1-level2 data
                        var sg_l = GameObject.Find("EventSystem").GetComponent<Sendtogoogle_level>();
                        if (sg_l != null)
                        {
                            sg_l.Send_burger();
                        }

                        GameOver.SetActive(true);

                    }
                    else
                    {
                        //timeRemaining = 180;
                        //timerIsRunning = true;
                        Ending.controller.Send("Succeess");
                      //  TimeUsedMenu.controller.displayTime(DisplayTime2(timeUsed));
                      //  SceneManager.LoadScene("TimeUsedScene");
                        SceneManager.LoadScene("CompletedMenu");
                        
                    }
                    
                  //  Schedule<PlayerDeath>();
                    DisplayTime(timeRemaining);
                } 
            
            }
            UpdateJumpState();
            base.Update();
        }


        void DisplayTime(float timeToDisplay)
        {
            //timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            //Debug.LogFormat("timeToDisplay = {0}, minutes = {1}, seconds = {2}", timeToDisplay, minutes, seconds);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        /*
        string DisplayTime2(float timeToDisplay)
        {
            //timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            //Debug.LogFormat("timeToDisplay = {0}, minutes = {1}, seconds = {2}", timeToDisplay, minutes, seconds);

            usingTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }*/

        string timePeriod(string currentTime){
            char[] seperator = {':'};
            int count = 2;
            string[] timelist = currentTime.Split(seperator, count, StringSplitOptions.None);
            int secondRemain = Convert.ToInt32(timelist[1]);

            if(secondRemain >= 50) return "59s - 50s";
            if(secondRemain >= 40) return "49s - 40s";
            if(secondRemain >= 30) return "39s - 30s";
            if(secondRemain >= 20) return "29s - 20s";
            if(secondRemain >= 10) return "19s - 10s";
            return "9s - 0s";
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}