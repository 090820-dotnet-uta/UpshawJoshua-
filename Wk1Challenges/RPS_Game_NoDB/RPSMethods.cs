using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS_Game_NoDB
{
    public class RPSMethods
    {
        public static int GetMenuChoice()
        {
             //get a choice from the user (play or quit)
            int userChoice;
            bool inputInt; //for parsing
            do//prompt loop
            {
                System.Console.WriteLine("Please choose 1 for Play or 2 for Quit");
                string input = Console.ReadLine();
                inputInt = int.TryParse(input, out userChoice);
            } while (!inputInt || userChoice <= 0 || userChoice >= 3);//end of promt loop
            return userChoice;
        }
        public static string GetPlayerName()
        {
            int testConvert;
            string playerName;
            do
            {
                //get the player name
                System.Console.WriteLine("What is your name?");
                playerName = Console.ReadLine();
                if(playerName == "computer" || playerName == "Computer" || int.TryParse(playerName, out testConvert))
                {Console.WriteLine("\t--Invalid Entry, please retry.");};
            //Keep reentereing till its a valid name that is a string and isnt computer
            }while(playerName == "computer" || playerName == "Computer" || int.TryParse(playerName, out testConvert)); 
            playerName = playerName.Trim();
            return playerName;   
        }//end getName method 

        public static Player PlayerVerify(List<Player> player, string playerName)
        {
            Player p1 = new Player();//p1 is null here.
                // check the list of players to see if this player is a returning player.
                foreach (Player item in player)
                {
                    if (item.Name == playerName)
                    {
                        p1 = item;
                        System.Console.WriteLine("You are a returning player");
                        break;//end the foreach loop
                    }
                }
                if (p1.Name == "null")//means the players name was not found above
                {
                    p1.Name = playerName;
                    player.Add(p1);
                }
                return p1;
        }//end verify method

        /// <summary>
        /// Allows player to choose Rock, Paper or Scissors (0,1,2)
        /// </summary>
        /// <returns>Choice of player</returns>
        public static Choice GetPlayerChoice()
        {
            //Declare our variable for use in parsing here to keep it in context
            int userChoice; 
            Choice p1Choice;
            do
            {
                Console.WriteLine("\t--Choose your weapon!--\n\t0)Rock\t1)Paper\t2)Scissors");
                //Read into our string userInput
                string userInput = Console.ReadLine();   
                 //Check to make sure the entry is an int before parsing it       
                if(!int.TryParse(userInput, out userChoice))   
                {                                              
                    Console.WriteLine("\tThat is not a number! Reenter!");
                    continue;
                }
                //Take userInput, parse it into our int
                int.TryParse(userInput, out userChoice);                  
                //Console.WriteLine($"userchoice is {userChoice}");
                //if valid entry break from loop to set p1Choice and return
                if(userChoice == 0 || userChoice == 1 || userChoice == 2) {break;}
                //Check and see if the input can be converted to a choice, loop back if not
                else{Console.WriteLine("\tThat entry is invalid! Please reenter!");}
            }while(userChoice != 0 || userChoice != 1 || userChoice != 2);  //Keep loop going until valid entry given
            p1Choice = (Choice)userChoice; 
            Console.WriteLine($"\tYou chose {p1Choice}! Good Luck!");
            return p1Choice;
        }
        public static Choice GetCompChoice()
        {
            Random rand = new Random();
            return (Choice)rand.Next(3);
        }
        public static void PrintAllData(List<Game> games, List<Player> players, List<Round> rounds)
        {
            foreach (var game in games)
            {
                System.Console.WriteLine($"Player1 Name => {game.Player1.Name}\ncomputer Name => {game.Computer.Name}\n winner is => {game.winner.Name}");
                System.Console.WriteLine($"\t--- Here are the games rounds --- ");
                foreach (Round round in game.rounds)
                {
                    System.Console.WriteLine($"player1 => {round.player1.Name}, p1 choice => {round.p1Choice}");
                    System.Console.WriteLine($"player2 => {round.Computer.Name}, computer choice => {round.ComputerChoice}");
                    System.Console.WriteLine($"the Outcome of this round is =>{round.Outcome}");


                }
            }
            System.Console.WriteLine("Here is the list of players.");
            foreach (var player in players)
            {
                System.Console.WriteLine($"This players name is {player.Name} and he has {player.record["wins"]} wins and {player.record["losses"]} losses");
            }
        }

        public static int WhoWon(Game game)
        {
            //search the game.rounds List<> to see if one player has 2 wins
            //if not loop to another round
            if (game.rounds.Count(x => x.Outcome == 1) == 2) { return 1; }
            else if (game.rounds.Count(x => x.Outcome == 2) == 2) { return 2; }// get how many rounds computer has won.
            else return 0;
        }

        public static void GetRoundWinner(Round round)
        {
           //check the choices to see who won.
            if (round.p1Choice == round.ComputerChoice)
            {
                round.Outcome = 0; // it’s a tie . the default is 0 so this line is unnecessary.
                System.Console.WriteLine("\tThis round was a tie");
            }
            //If user score higher than comp by 1, user win
            else if ((int)round.p1Choice == ((int)round.ComputerChoice + 1) % 3)
            {
                Console.WriteLine("\tPlayer Won");
                round.Outcome = 1;
            }
            else{Console.WriteLine("\tComp Won"); round.Outcome = 2;}
        }
    }
}