using System.Collections;
using System.Collections.Generic;
using Platformer.Core;
using Platformer.Model;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player has died.
    /// </summary>
    /// <typeparam name="PlayerDeath"></typeparam>
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var player = model.player;
            if (player.health.IsAlive)
            {

                // send ingredients data to collect
                var tempgameObject = new GameObject();
                Sendtogoogle sg = tempgameObject.AddComponent<Sendtogoogle>();
                sg.Send();

                // send level1-level2 data
                
                var sg_l = GameObject.Find("EventSystem").GetComponent<Sendtogoogle_level>();
                if(sg_l != null)
                {
                    sg_l.Send_burger();
                }

                if (MeatCounterScript.instance){
                    MeatCounterScript.instance.resetAmount();
                }
                if(VegetableCounterScript.instance){
                    VegetableCounterScript.instance.resetAmount();
                }
                if(BreadCounterScript.instance){
                    BreadCounterScript.instance.resetAmount();
                }

                if(breadSliceCounterScript.instance){
                    breadSliceCounterScript.instance.resetAmount();
                }
                if(steakCounterScript.instance){
                    steakCounterScript.instance.resetAmount();
                }
                if(lettuceCounterScript.instance){
                    lettuceCounterScript.instance.resetAmount();
                }


                if(BurgerCounterScript.instance){
                    BurgerCounterScript.instance.resetAmount();
                }
                if(steamingBurgerCounterScript.instance){
                    steamingBurgerCounterScript.instance.resetAmount();
                }
                
                
//                CoinCounterScript.instance.resetAmount();
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                // player.collider.enabled = false;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);
                player.timeRemaining = 180;
                player.timerIsRunning = true;
                Simulation.Schedule<PlayerSpawn>(2);
            }
        }
    }
}