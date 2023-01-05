using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_2_OOP.Program;
using System.Runtime.CompilerServices;

namespace Lab_2_OOP
{
    public abstract class Entity: IDisposable, IEntity, IThing
    {
        public event EatingHandle EntityEatingHandle;
        protected Random rnd = new Random();
        private int[] GenerateCoordinates()
        {
            int x, y;
            Random rnd = new Random();
            do
            {
                x = rnd.Next(Map.xLength);
                y = rnd.Next(Map.yLength);
            }
            while (Map.field[y, x] != 0);
            return new int[] { y, x };
        }
        public string name;
        protected int index;
        private bool disposed = false;
        public int xp;
        private Fruit fruit;
        public abstract int Level {get; set;}
        public int x, y;
        public int[] Coordinates { get=> new int[] { y, x }; set { y = value[0]; x = value[1]; } }
        protected int health;
        public abstract int Health{ get; set;}

        private int damage;
        public int Damage
        {
            get { return damage; }
            protected set { damage = value; }
        }
        public abstract void Move(Fruit fruit);
        public void AddFruit(Fruit fruit)
        {
            this.fruit = fruit;
        }
        protected Entity()
        {
            Coordinates = GenerateCoordinates();
            IEntity.attackState = 2;
            IEnemy.attackState = 0;
            this.name = "Сутність";
        }
        public void Dispose()
        {
            movement -= entity.Move;
            movement -= ((IEnemy)entity).Move;
            CursorLeft = 0;
            WriteLine($"Ви успішно вбили {this.name} і отримали {(int)(player.difcIndex * this.xp) / 10} xp");
            ReadKey();
            CreatingCreatures(this.EntityEatingHandle, fruit);
            Map.field[this.y, this.x] = 0;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)

        {
            if (disposed) return;
            if (disposing)
                GC.Collect();
            ConsoleLog.ToAdd($"{name} був видалений з пам'яті.");
            disposed = true;
        }
        ~Entity()
        {
            Dispose(false);
        }
        public void Eating()
        {
            FruitEventArgs args = new FruitEventArgs();
            if (EntityEatingHandle != null)
                EntityEatingHandle(this, args);
        }
    }
    public static class EntityExtension
    {
        public static void Scream(this Entity monster)
        {
            if (ConsoleLog.LastElement()!= $"{entity.name} закричав і починає тікати.")
            {
                ConsoleLog.ToAdd($"{entity.name} закричав і починає тікати.");
                movement -= entity.Move;
                movement += ((IEnemy)entity).Move;
            }
        }
    }
}
