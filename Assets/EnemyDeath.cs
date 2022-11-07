using Platformer.Core;
using Platformer.Mechanics;
using System;
using Platformer.Gameplay;
using UnityEngine;


namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the health component on an enemy has a hitpoint value of  0.
    /// </summary>
    /// <typeparam name="EnemyDeath"></typeparam>
    public class EnemyDeath : Simulation.Event<EnemyDeath>
    {
        public EnemyController enemy;
        
        public override void Execute()
        {
          
            
            RewardCookingSpot.Instance.changePos();
            





            enemy._collider.enabled = false;
            enemy.control.enabled = false;
          
            if (enemy._audio && enemy.ouch)
            {
                enemy._audio.PlayOneShot(enemy.ouch);
                
            }
               
        }
    }
}