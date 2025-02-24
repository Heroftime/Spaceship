﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship
{
    class Asteroid
    {
        public Vector2 position = new Vector2(600, 300);
        public int speed;
        public int radius = 59;

        public Asteroid(int newSpeed)
        {
            speed = newSpeed;
            Random random = new();
            position = new Vector2(1380, random.Next((radius / 2), 721 - (radius / 2)));
        }

        public void asteroidUpdate(GameTime gameTime)
        {
           float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X -= speed * dt;
        }
    }
}
