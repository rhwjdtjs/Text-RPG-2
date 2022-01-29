using System;
using System.Collections.Generic;
using System.Text;

namespace unityclass
{
    public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field 
    }
    class Game
    {
        private GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        private Random random = new Random();

        public void Process()
        {
            switch (mode)
            {
                case GameMode.None:
                    Console.WriteLine("텍스트 알피지에 오신것을 환영합니다");
                    Console.WriteLine("게임 시작을 위해 곧바로 로비로 안내해드리겠습니다.");
                    break;
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }
        public void ProcessField()
        {
            Console.WriteLine("필드에 입장하셨습니다!");
            Console.WriteLine("[1] 싸우기");
            
           

           string input=Console.ReadLine();
            switch(input)
            {
                case "1":
                    CreateRandomMonster();
                    ProcessFight();
                    break;
            }
        }
        private void TryEscape()
        {
            int randvalue = random.Next(0, 100);
            if(randvalue<33)
            {
                mode = GameMode.Town;
            }
            else
            {
                ProcessFight();
            }
        }
        private void ProcessFight()
        {
            while(true)
            {
                int damage;
                Console.WriteLine("적과 조우 했습니다");
                Console.WriteLine("[1]공격하기");
                Console.WriteLine("[2]스킬사용");
                Console.WriteLine("[3]도망가기");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        damage = player.GetAttack();
                        monster.Ondamaged(damage);
                        Console.WriteLine($"플레이어는{player.GetAttack()}만큼 데미지를 주었습니다\n몬스터의 남은 체력{monster.GetHp()} ");
                        Console.WriteLine($"{monster}의 차례!");
                        damage = monster.GetAttack();
                        player.Ondamaged(damage);
                        Console.WriteLine($"플레이어는{monster.GetAttack()}만큼 데미지를 입었습니다\n플레이어의 남은 체력{player.GetHp()}");
                        break;
                    case "2":
                        Console.WriteLine("개발중입니다.");
                        break;
                    case "3":
                        TryEscape();
                        break;
                }
                if (player.Isdead())
                {
                    Console.WriteLine("패배했습니다");
                    mode = GameMode.Town;
                    break;
                }
                if (monster.Isdead())
                {
                    Console.WriteLine("승리했습니다");
                    Console.WriteLine("마을로 돌아갑니다.");
                    mode = GameMode.Town;
                    break;
                }
            }
        }
        private void CreateRandomMonster()
        {
            int randvalue = random.Next(0, 3);
            switch (randvalue)
            {
                case 0:
                    monster = new Slime();
                    Console.WriteLine("슬라임이 생성되었습니다.");
                    break;
                case 1:
                    monster = new Orc();
                    Console.WriteLine("오크가 생성되었습니다.");
                    break;
                case 2:
                    monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 생성되었습니다.");
                    break;
            }
        }
        public void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다!");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기") ;
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }
        public void ProcessLobby()
        {
            Console.WriteLine("직업을 선택하세요");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[1] 마법사");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }
        }

    }
}
