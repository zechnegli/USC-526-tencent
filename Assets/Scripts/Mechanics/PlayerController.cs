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
        public int expectCustomers = 5;
        public bool sendTime = false;
        public static PlayerController Instance;
        private bool firstJump = true;

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
            if (Instance == null)
            {
                Instance = this;
            }
          
          //  arrowHide.instance.hide();
         //   KillText.instance.show("←A ↑space  D→", 6);
          //  KillText.instance.show("↑ space", 6);
        }

        protected override void Update()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (controlEnabled)
            {
                move.x = Input.GetAxis("Horizontal");
                if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump")){
                    jumpState = JumpState.PrepareToJump;
                    if(sceneName == "Level1_Scene" && firstJump){
                        KillText.instance.show("Long Press To Jump Higher", 6);
                        firstJump = false;
                    }
                 }
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

            
            if (sceneName == "Level1_Scene"){
                arrowHide.instance.hide();
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

                    Scene currentscene = SceneManager.GetActiveScene();
                    string scenename = currentscene.name;
                    if(scenename == "Level3_Scene" && customerCounterScript.instance.amount >= 1 && sendTime == false){
                        SceneManager.LoadScene("Level3CompletedMenu");
                        SceneManager.UnloadScene(scenename);
                    }
                    else if(scenename == "Level1_Scene" && customerCounterScript.instance.amount >= 5 && sendTime == false){
                        SceneManager.LoadScene("Level1CompletedMenu");
                        SceneManager.UnloadScene(scenename);
                    }
                    else if(scenename == "Level2_Scene" && customerCounterScript.instance.amount >= 5 && sendTime == false){
                        SceneManager.LoadScene("Level2CompletedMenu");
                        SceneManager.UnloadScene(scenename);
                    }
                    else if(scenename == "Level4_Scene" && customerCounterScript.instance.amount >= 3 && sendTime == false){
                        SceneManager.LoadScene("Level4CompletedMenu");
                        SceneManager.UnloadScene(scenename);
                    }

                     //   if(CoinCounterScript.instance.amount >= expectCoins && sendTime == false)
                     /*
                     if(scenename != "Level3_Scene" && customerCounterScript.instance.amount >= expectCustomers && sendTime == false)
                    {
                        TimeDataCollection.controller.Send(timePeriod(timeText.text));
                        Ending.controller.Send("Succeess");
                        sendTime = true;
                        //load the success page when player collect expectCoins amount of coins
                       // Scene currentscene = SceneManager.GetActiveScene();
                       // string scenename = currentscene.name;

                        if (scenename == "Level1_Scene")
                        {

                            SceneManager.LoadScene("Level1CompletedMenu");
                        }
                        else if (scenename == "Level2_Scene")
                        {
                            SceneManager.LoadScene("Level2CompletedMenu");
                           
                        }
                        /*
                        else if (scenename == "Level3_Scene")
                        {
                            SceneManager.LoadScene("Level3CompletedMenu");
                           
                        }
                        else
                        {
                            SceneManager.LoadScene("Level4CompletedMenu");
                          
                        }
                        SceneManager.UnloadScene(scenename);

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




                         }*/


                }
                else
                {

                    timeRemaining = 0;
                    timerIsRunning = false;
                    
                    if(customerCounterScript.instance.amount<expectCustomers)
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

        public void addTimeReward(int timeReward)
        {
            this.timeRemaining += timeReward;
        }

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
        //public void OnTriggerExit2D(Collider2D other)
        //{
        //    if (other.gameObject.CompareTag("Player"))
        //    {
        //        if (this.gameObject.name == "door1")
        //        {
        //            KillText.instance.show("Press E Return To Cooking", 2);
        //            if (Input.GetKeyDown(KeyCode.E))
        //            {
        //                GameObject player_transform = GameObject.Find("Player");
        //                player_transform.transform.position = new Vector3(6, 0, 0);
        //            }

        //        }
        //    }
        //}
    }
}