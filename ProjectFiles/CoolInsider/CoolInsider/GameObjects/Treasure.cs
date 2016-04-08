﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreasureHunter
{
    public class Treasure : GameObject
    {
        /*
         * Created By Joshua Ray
         * 11/11/2012
         * 
         * Class that represents the Treaures of the game
         * 
         */

        bool dead;
        public int color;
        /// <summary>
        /// Constructor. Places the enemy at the given Mazeblock. The 
        /// mazeblock should be walkable
        /// </summary>
        /// <param name="StartBlock">Starting block</param>
        public Treasure(MazeBlock StartBlock) {
            kinetics = Kinetic.ZERO();

            Random rand = new Random(DateTime.Now.Millisecond);
            color = rand.Next(0,2);
            switch (color)
            {
                case 0:
                    sprite = TreasureHunter.content.Load<Texture2D>(@"PlanetCute\Gem Blue");
                    break;
                case 1:
                    sprite = TreasureHunter.content.Load<Texture2D>(@"PlanetCute\Gem Green");
                    break;
                case 2:
                    sprite = TreasureHunter.content.Load<Texture2D>(@"PlanetCute\Gem Orange");
                    break;
            }
            kinetics.position = new Vector2(StartBlock.kinetics.boundingBox.Center.X - sprite.Width / 2,
                                            StartBlock.kinetics.boundingBox.Center.Y - sprite.Height / 2);
            Kinetic.SetBoundingBoxDimensions(ref kinetics.boundingBox, sprite);
            kinetics.Update();
        }

        /// <summary>
        /// Test if Enemy is dead or not
        /// </summary>
        /// <returns>True if dead == true, false otherwise</returns>
        public override bool Dead()
        {
            return dead;
        }

        /// <summary>
        /// Updates the Enemy
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Unused. Store attack logic here.
        /// </summary>
        public override void Attack()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for resolving collisions with given Item
        /// </summary>
        /// <param name="Item">Item that has collided with this</param>
        public override void CollisionResolution(GameObject Item)
        {
            if (Item.GetType() == typeof(Avatar))
            {
                dead = true;
                LevelManager.Instance().GenerateNextLevel();
            }
        }

    }
}
