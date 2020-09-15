using System;
using System.Collections.Generic;
using System.Linq;

namespace RPS_Game_NoDB
{
    public enum Choice
    {
        Rock,//can be accessed with a 0
        Paper,//can be accessed with a 1
        Scissors//can be accessed with a 2
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Game> games = new List<Game>();
            List<Round> rounds = new List<Round>();
            int choice;
            Player computer = new Player() { Name = "Computer" };//instantiate a Player and give a value to the Name all at once.
            players.Add(computer);
            int gameCounter = 1;

            do//begin game loop
            {
                System.Console.WriteLine($"\n\t\tThis is game #{gameCounter++}\n\n");

                //get a choice from the user (play or quit)
                choice = RPSMethods.GetMenuChoice();
                if(choice==2){break;}

                //get the player name
                string playerName = RPSMethods.GetPlayerName();
                Player p1 = new Player();//p1 is set to null here.
                p1 = RPSMethods.PlayerVerify(players, playerName);

                Game game = new Game();     // create a new game
                game.Player1 = p1;          // set p1 as the player in the game
                game.Computer = computer;   // and comp as the 2nd player

                Random rand = new Random();

                //play rounds till one player has 2 wins
                //assign the winner to the game and check that property to break out of the loop.
                while (game.winner.Name == "null")
                {
                    Round round = new Round();//declare a round for this iteration
                    round.game = game;// add the game to this round
                    round.player1 = p1;// add user (p1) to this round
                    round.Computer = computer;// add computer to this round

                    //get the choices for the 2 players
                    //insert the players choices directly into the round
                    round.p1Choice = RPSMethods.GetPlayerChoice();
                    round.ComputerChoice = RPSMethods.GetCompChoice();

                    //find round winner
                    RPSMethods.GetRoundWinner(round);
                    //add this round to the games List of rounds
                    game.rounds.Add(round);

                    //search the game.rounds List<> to see if one player has 2 wins, if so return from func,
                    //if not loop to another round
                    int Winner = RPSMethods.WhoWon(game);
                    //assign the winner to the game and increment wins and losses for both
                    if (Winner == 1)
                    {
                        game.winner = p1;
                        p1.record["wins"]++;//increments wins and losses.
                        computer.record["losses"]++;//increments wins and losses.
                        Console.WriteLine("\t--You won! It totally wasn't blind luck!--");
                    }
                    else if (Winner == 2)
                    {
                        game.winner = computer;
                        p1.record["losses"]++;//increments wins and losses.
                        computer.record["wins"]++;//increments wins and losses.
                        Console.WriteLine("\t--You lost! Sucks to be you!--");
                    }
                }//end of rounds loop
                //Add this game to the list of games
                games.Add(game);
            } while (choice != 2);//end of game loop
            //Once the player chooses to leave, print the data
            RPSMethods.PrintAllData(games, players, rounds);
        }//end of main
    }//end of program
}//end of namaespace
