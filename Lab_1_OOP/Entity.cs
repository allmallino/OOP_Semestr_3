using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_1_OOP.Program;

namespace Lab_1_OOP
{
    public class Entity: IDisposable
    {
        protected Random rnd = new Random();
        protected int attackState;
        public string name;
        protected int index;
        private bool disposed = false;
        public int xp;
        public virtual int Level
        {
            get { return xp / 100; }
            set { xp += value; }
        }
        public int x, y;
        protected int health;
        public virtual int Health
        {
            get { return health; }
            set { health += value; }
        }

        private int damage;
        public int Damage
        {
            get { return damage; }
            protected set { damage = value; }
        }
        public virtual void GetHit(Fruit fruit)
        {
            entity.health -= player.damage;
            if (entity.health <= 0)
            {
                player.Level = entity.xp / 10;
                Dispose();
                return;
            }
            player.GetHit(fruit);
            attackState = 2;
        }
        public virtual void Move(Fruit fruit)
        {
            if (attackState == 0)
            {
                int newCord;
                if (Math.Abs(this.x - player.x) >= Math.Abs(this.y - player.y))
                {
                    newCord = this.x + Math.Abs(player.x - this.x) / (player.x - this.x);
                    if (Map.field[this.y, newCord] == 0)
                    {
                        Map.field[this.y, newCord] = index;
                        Map.field[this.y, this.x] = 0;
                        this.x = newCord;
                    }
                    else if (Map.field[this.y, newCord] == 3)
                        fruit.ToGive(entity);
                    else
                    {
                        player.GetHit(fruit);
                        attackState = 2;
                    }
                }
                else
                {
                    newCord = this.y + Math.Abs(player.y - this.y) / (player.y - this.y);
                    if (Map.field[newCord, this.x] == 0)
                    {
                        Map.field[newCord, this.x] = index;
                        Map.field[this.y, this.x] = 0;
                        this.y = newCord;
                    }
                    else if (Map.field[newCord, this.x] == 3)
                        fruit.ToGive(entity);
                    else
                    {
                        player.GetHit(fruit);
                        attackState = 2;
                    }
                }
            }
            else
                attackState--;
        }
        protected Entity()
        {
            int x, y;
            do
            {
                x = rnd.Next(Map.xLength);
                y = rnd.Next(Map.yLength);
            }
            while (Map.field[y, x] != 0);
            this.y = y;
            this.x=x;
            this.attackState = 2;
            this.name = "Сутність";
        }
        public void Dispose()
        {
            CursorLeft = 0;
            WriteLine($"Ви успішно вбили {this.name} і отримали {this.xp / 10} xp");
            ReadKey();
            CreatingCreatures();
            Map.field[this.y, this.x] = 0;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)

        {
            if (disposed) return;
            if (disposing)
                GC.Collect();

            for (int i = 0; i < consoleLog.Length; i++)
            {
                if (consoleLog[i] == null)
                {
                    consoleLog[i] = $"{name} був видалений з пам'яті.";
                    disposed = true;
                    return;
                }
            }
            for (int i = 0; i < consoleLog.Length - 1; i++)
            {
                consoleLog[i] = consoleLog[i + 1];
            }
            consoleLog[consoleLog.Length - 1] = $"{name} був видалений з пам'яті.";
            disposed = true;
        }
        ~Entity()
        {
            Dispose(false);
        }
    }
}
