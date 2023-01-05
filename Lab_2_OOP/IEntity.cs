using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_2_OOP.Program;

namespace Lab_2_OOP
{
    internal interface IEntity
    {
        protected static int attackState;
        public void GetHit(Fruit fruit)
        {
            entity.Health = -player.Damage;
            if (entity.Health <= 0)
            {
                player.Level = entity.xp / 10;
                entity.Dispose();
                return;
            }
            player.GetHit(fruit);
            attackState = 2;
            IEnemy.attackState = 2;
        }
        public void Move(Fruit fruit){ }
    }
}
