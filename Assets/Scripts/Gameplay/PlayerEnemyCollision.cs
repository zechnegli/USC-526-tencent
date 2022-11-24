using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;
using static Platformer.Core.Simulation;
using Random = System.Random;

namespace Platformer.Gameplay
{

    /// <summary>
    /// Fired when a Player collides with an Enemy.
    /// </summary>
    /// <typeparam name="EnemyCollision"></typeparam>
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;
        public bool sendDeathInfo = false;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var willHurtEnemy = player.Bounds.center.y >= enemy.Bounds.max.y;

            if (willHurtEnemy)
            {
                var enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyDeath>().enemy = enemy;
                        player.Bounce(2);
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Debug.Log("killed enemy");
                    Schedule<EnemyDeath>().enemy = enemy;
                    player.Bounce(2);
                    randomRewards();
                  
                }
            }
            else
            {
                Schedule<PlayerDeath>();
               // if(sendDeathInfo == false){
                 DeathReason.controller.Send("Enemy Collision");
                 Ending.controller.Send("Fail");
               //  sendDeathInfo = true;
               // }
               
            }
        }
        
        public void randomRewards() {
            Random random = new Random();
            int rewards = random.Next(0, 2);
            if (rewards == 0) {
                PlayerController.Instance.addTimeReward(10);
                KillText.instance.ChangeAmount("+10s");
            } else {
                  if (BreadCounterScript.instance && MeatCounterScript.instance && VegetableCounterScript.instance)
                    {
                        Random rd = new Random();
                        int rd_num = rd.Next(1, 4);
                        if (rd_num == 1)
                        {
                            BreadCounterScript.instance.killbouns();
                            KillText.instance.ChangeAmount("+Bread");
                        }
                        if (rd_num == 2)
                        {
                            MeatCounterScript.instance.killbouns();
                            KillText.instance.ChangeAmount("+Meat");
                        }
                        if (rd_num == 3)
                        {
                            VegetableCounterScript.instance.killbouns();
                            KillText.instance.ChangeAmount("+Vegetable");
                        }
                    }

                    if (BurgerCounterScript.instance)
                    {
                        BurgerCounterScript.instance.killbouns();
                        KillText.instance.ChangeAmount("+Burger");

                    }
            }
        }
    }
    
    
}