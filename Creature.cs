using System;
using System.Collections.Generic;
using System.Text;

namespace unityclass
{
    public enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }
    class Creature
    {
        CreatureType type;
       protected Creature(CreatureType type)
        {
            this.type = type;
        }
        protected int hp = 0;
        protected int attack = 0;
        protected int exp = 0;
        public void Setinfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
        public int Getexp() { return exp; }
        public int GetHp() { return hp; }
        public int GetAttack() { return attack; }
        public bool Isdead() { return hp <= 0; }
        public void Ondamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
                hp = 0;
        }
    }
}
