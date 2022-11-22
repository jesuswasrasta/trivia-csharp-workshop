using System;


using UglyTrivia;

namespace Trivia
{
    
    public class GameRunner
    {
        public static void Main(String[] args)
        {
            Random rand = new Random();

            Play(rand);
        }

        public static void Play(Random rand)
        {
            Game aGame = new Game();

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");


            do
            {
                aGame.roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }

        private static bool notAWinner;
    }

}

