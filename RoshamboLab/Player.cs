using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RoshamboLab
{
    public abstract class Player
    {
        public string PlayerName { get; set; }
        public string RoshamboUserValue { get; protected set; }

        public abstract RoshamboEnum GenerateRoshambo();
    }

    public class RockPlayer : Player
    {
        public RockPlayer(string name)
        {
            PlayerName = name;
        }
        public override RoshamboEnum GenerateRoshambo()
        {
            return RoshamboEnum.rock;
        }
    }

    public class RandomPlayer : Player
    {
        private static readonly Random _random = new Random();

        public RandomPlayer(string name)
        {
            PlayerName = name;
        }

        public override RoshamboEnum GenerateRoshambo()
        {
            Array values = Enum.GetValues(typeof(RoshamboEnum));
            return (RoshamboEnum)values.GetValue(_random.Next(values.Length));
        }
    }
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name)
        {
            PlayerName = name;
        }

        public override RoshamboEnum GenerateRoshambo()
        {
            while (true)
            {
                Console.WriteLine($"{PlayerName}, please choose Rock (R), Paper (P), or Scissors (S):");
                string input = Console.ReadLine().ToLower();

                if (input == "r")
                    return RoshamboEnum.rock;
                else if (input == "p")
                    return RoshamboEnum.paper;
                else if (input == "s")
                    return RoshamboEnum.scissors;

                Console.WriteLine("This is not a valid input, please try again.");
            }
        }
    }
}


