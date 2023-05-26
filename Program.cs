using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        public static int challengeSuccess = 0;
        public static void increaseSuccessCount()
        {
            challengeSuccess++;
        }
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge


            bool repeatQuest = true;
            


            while (repeatQuest)
            {
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            Challenge favCity = new Challenge(@"What is my fav city?
    1) St. Louis
    2) Huntington
    3) The one your mom lives in
    4) San Diego
",
                3, 20);
                Challenge favAnimal = new Challenge(@"What is my fav animal?
    1) panda
    2) squirrel
    3) pig
    4) spider
",
                1, 25);
                Challenge mathProb = new Challenge("2 + 2 - 6 * 5?", 69, 10);

                      Challenge favSport = new Challenge(@"What is my fav sport?
    1) tennis
    2) volleyball
    3) golf
    4) disc golf
",
                1, 25);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.WriteLine("Enter adventurer name");
            string userName = Console.ReadLine();

            List<string> robeColors = new List<string> { "purple", "red" };
            Robe colorfulRobe = new Robe { Colors = robeColors, Length = 47 };

            Hat shinyHat = new Hat { ShininessLevel = 8 };

            Adventurer theAdventurer = new Adventurer(userName, colorfulRobe, shinyHat);

            Console.WriteLine(theAdventurer.GetDescription());
            Console.WriteLine();

           

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> allChallenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                favCity,
                favAnimal,
                mathProb,
                favSport
            };

            List<Challenge> selectedChallenges = SelectRandomChallenges(allChallenges, 5);

            // Loop through all the challenges and subject the Adventurer to them
            foreach (Challenge challenge in selectedChallenges)
            {
                challenge.RunChallenge(theAdventurer);
            }

            // This code examines how Awesome the Adventurer is after completing the challenges
            // And praises or humiliates them accordingly
            if (theAdventurer.Awesomeness >= maxAwesomeness)
            {
                Console.WriteLine("YOU DID IT! You are truly awesome!");
            }
            else if (theAdventurer.Awesomeness <= minAwesomeness)
            {
                Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
            }
            else
            {
                Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
            }

             Prize questPrize = new Prize("Congrats! you win a prize ");
             questPrize.ShowPrize(theAdventurer);

                Console.WriteLine("Do you want to repeat quest? (yes/no): ");
                string repeat = Console.ReadLine();

                if (repeat.ToLower() != "yes")
                {
                    repeatQuest = false;
                     challengeSuccess = (challengeSuccess * 10);
                theAdventurer.Awesomeness += challengeSuccess;
                challengeSuccess = 0;
                Console.WriteLine($"Awesomeness Level: {theAdventurer.Awesomeness}");
                }

                Console.WriteLine();

            }
        }
            static List<Challenge> SelectRandomChallenges(List<Challenge> allChallenges, int numChallenges)
        {
            List<Challenge> selectedChallenges = new List<Challenge>();
            Random random = new Random();

            while (selectedChallenges.Count < numChallenges && allChallenges.Count > 0)
        {
            int randomIndex = random.Next(allChallenges.Count);
            Challenge selectedChallenge = allChallenges[randomIndex];
            selectedChallenges.Add(selectedChallenge);
            allChallenges.RemoveAt(randomIndex);
        }

            return selectedChallenges;
        }
    }
}