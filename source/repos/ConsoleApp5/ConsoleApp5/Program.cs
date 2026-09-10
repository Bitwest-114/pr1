using System;
using System.Text;

namespace AdventureGameStrategy
{
    public interface IWeaponBehavior
    {
        void UseWeapon();
    }

    public abstract class Character
    {
        private IWeaponBehavior _weaponBehavior;

        protected Character(IWeaponBehavior weaponBehavior)
        {
            if (weaponBehavior == null)
            {
                throw new ArgumentNullException(nameof(weaponBehavior));
            }

            _weaponBehavior = weaponBehavior;
        }

        public void SetWeapon(IWeaponBehavior weaponBehavior)
        {
            if (weaponBehavior == null)
            {
                throw new ArgumentNullException(nameof(weaponBehavior));
            }

            _weaponBehavior = weaponBehavior;
        }

        public void Fight()
        {
            Console.Write(GetType().Name + ": ");
            _weaponBehavior.UseWeapon();
        }

        // Унікальний опис для кожного типу персонажа
        public abstract void Display();
    }

    public class Knight : Character
    {
        public Knight() : base(new SwordBehavior()) { }

        public override void Display()
        {
            Console.WriteLine("Лицар виходить на поле бою.");
        }
    }

    public class Mage : Character
    {
        public Mage() : base(new StaffBehavior()) { }

        public override void Display()
        {
            Console.WriteLine("Маг готує заклинання.");
        }
    }

    public class Archer : Character
    {
        public Archer() : base(new BowBehavior()) { }

        public override void Display()
        {
            Console.WriteLine("Лучник займає позицію на пагорбі.");
        }
    }

    public class Rogue : Character
    {
        public Rogue() : base(new DaggerBehavior()) { }

        public override void Display()
        {
            Console.WriteLine("Розбійник ховається у тінях.");
        }
    }

    public class SwordBehavior : IWeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("рубає мечем.");
        }
    }

    public class BowBehavior : IWeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("стріляє з лука.");
        }
    }

    public class StaffBehavior : IWeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("кидає вогняну кулю з посоха.");
        }
    }

    public class DaggerBehavior : IWeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("завдає швидкого удару кинджалом.");
        }
    }

    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Character[] characters =
            {
                new Knight(),
                new Mage(),
                new Archer(),
                new Rogue()
            };

            Console.WriteLine("Початкове озброєння персонажів:");
            foreach (Character character in characters)
            {
                character.Display();
                character.Fight();
            }

            Console.WriteLine("\nПід час гри лицар змінює меч на кинджал:");
            Character knight = characters[0];
            knight.SetWeapon(new DaggerBehavior());
            knight.Fight();

            Console.WriteLine("\nМаг змінює посох на лук:");
            Character mage = characters[1];
            mage.SetWeapon(new BowBehavior());
            mage.Fight();
        }
    }
}