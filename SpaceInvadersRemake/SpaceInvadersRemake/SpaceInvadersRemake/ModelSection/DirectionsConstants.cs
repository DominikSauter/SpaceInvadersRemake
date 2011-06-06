using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    public static class DirectionsConstants
    {
        //Directions Definitions


        public static Vector2 Up
        {
            public get
            {
                return new Vector2(0.0f, 1.0f);
            }
        }
        public static Vector2 Down
            {
            public get
            {
                return new Vector2(0.0f, -1.0f);
            }
        }
        public static Vector2 Right
            {
            public get
            {
                return new Vector2(1.0f, 0.0f);
            }
        }
        public static Vector2 Left
        {
            public get
            {
                return new Vector2(-1.0f, 0.0f);
            }
        }
    }
}
