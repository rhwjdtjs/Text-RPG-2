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
        public void Setinfo(int hp, int attack,int exp)
        {
            this.hp = hp;
            this.attack = attack;
            this.exp = exp;
        }
        public void LevelUp(Player player)
        {
            if(player.exp>=100)
            {
                Console.WriteLine("플레이어의 레벨이 2가 되었습니다!!\n스택 상승!");
                Console.WriteLine("hp+10, attack+3");
                player.hp += 10;
                player.attack += 3;
            }
        }
        public void SetHp(Player player)
        {
            player.hp += 5;
        }
        public void Upexp(int exp)
        {
            this.exp += exp;
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
