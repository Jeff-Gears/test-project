using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno1
{
    class Program
    {
        static void Main(string[] args)
        {

            // create a game similar to Uno: use the below as guidance
            //removed wilds to change to suit of card to make code simpler feel free to change to suport full wild behaivior.
            //Ace is Draw 4 Card can be played at any time and will switch suit to the suit of the Ace
            //king is Wild card that can be played at any time and will switch suit to the suit of the King
            //Queen is Draw 2 Card Next player draws 2 cards
            //Jack is skip Card

            ///////// The below is just for guidance - you do not need to do it the way outlined below/////////////

            //create a list of players V
            //ask the user to enter a number of players 2-5 V
            //create as many players as indicated by user and add each to  the list of players V
            //create an object called gameDeck that is an instance of the deck class V
            //shuffle the game deck V
            //deal 7 cards to each player V 
            //draw the first card V
            //place card on the discard pile V
            //While the game is not over (players still have cards) V
            // check if previous card was special card(see above) and do what it tell you to do V
            // check currentPlayer's available moves V
            // if no moves are available draw a card until a move is available V
            // if valid move found prompt user to enter cardName V
            // play the card the user selected and discard the card. V
            // move to next player in the list V
            bool replay = true;
            int drawloop = 0;
            string choice;
            int numberOfPlayers;
            Player player1 = new Player();
            Player player2 = new Player();
            Player player3 = new Player();
            Player player4 = new Player();
            Player player5 = new Player();
            int playerMove = 0;
            int playerNumber=0;
            while (replay==true)
            {
                List<Player> playerList = new List<Player>();
                Console.WriteLine("how many players do you have pick 2-5");
                choice = Console.ReadLine();
                numberOfPlayers = Convert.ToInt32(choice);
                if (numberOfPlayers==2)
                {
                    playerList.Add(player1);
                    playerList.Add(player2);
                    Console.WriteLine("hello players");
                }
                else if (numberOfPlayers == 3)
                {
                    playerList.Add(player1);
                    playerList.Add(player2);
                    playerList.Add(player3);
                    Console.WriteLine("hello players");
                }
                else if (numberOfPlayers == 4)
                {
                    playerList.Add(player1);
                    playerList.Add(player2);
                    playerList.Add(player3);
                    playerList.Add(player4);
                    Console.WriteLine("hello players");
                }
                else if (numberOfPlayers == 5)
                {
                    playerList.Add(player1);
                    playerList.Add(player2);
                    playerList.Add(player3);
                    playerList.Add(player4);
                    playerList.Add(player5);
                    Console.WriteLine("hello players");
                }
                Deck gameDeck = new Deck();
                gameDeck.ShuffleAll();
                numberOfPlayers = numberOfPlayers - 1;
                while (numberOfPlayers >= 0)
                {
                    while (drawloop <= 7)
                    {
                        playerList[numberOfPlayers].AddCardToHand(gameDeck.DrawCard());
                        drawloop = drawloop + 1;
                    }
                    drawloop = 0;
                    numberOfPlayers = numberOfPlayers - 1;
                }
                Card startingCard = gameDeck.DrawCard();
                gameDeck.DiscardCard(startingCard);
                Console.WriteLine(gameDeck.ReadDiscardPile());
                while (playerList[playerMove].GetNumCards()>0)
                {
                    drawloop = 0;
                    if (gameDeck.ReadDiscardPile().GetValue()==11)
                    {
                        playerMove = playerMove + 1;
                        if (playerMove==playerList.Count)
                        {
                            playerMove = 0;
                        }
                    }
                    else if (gameDeck.ReadDiscardPile().GetValue() == 12)
                    {
                        while (drawloop < 2)
                        {
                            playerList[playerMove].AddCardToHand(gameDeck.DrawCard());
                            drawloop = drawloop + 1;
                        }
                    }
                    else if (gameDeck.ReadDiscardPile().GetValue() ==14)
                    {
                        while (drawloop < 4)
                        {
                            playerList[playerMove].AddCardToHand(gameDeck.DrawCard());
                            drawloop = drawloop + 1;
                        }
                    }
                    playerNumber = playerMove + 1;
                    Console.WriteLine("player"+playerNumber+"'s turn");
                    playerList[playerMove].PrintValidMoves(gameDeck.ReadDiscardPile());
                    while (playerList[playerMove].PrintValidMoves(gameDeck.ReadDiscardPile()) == false)
                    {
                        playerList[playerMove].AddCardToHand(gameDeck.DrawCard());
                        playerList[playerMove].PrintValidMoves(gameDeck.ReadDiscardPile());
                    }
                    playerList[playerMove].PrintAllCards();
                    bool validmove = false;
                    while (!validmove)
                    {
                        choice = Console.ReadLine();
                        validmove = playerList[playerMove].checkValidMoves(gameDeck.ReadDiscardPile(), choice);
                    }
                    gameDeck.DiscardCard(playerList[playerMove].GetCardByName(choice));
                    playerMove = playerMove + 1;
                    if (playerMove == playerList.Count)
                    {
                        playerMove = 0;
                    }
                }
                Console.WriteLine("Player" + playerNumber+ " wins");
                Console.WriteLine("play again? y/n");
                choice = Console.ReadLine();
                if (choice == "n")
                {
                    replay = false;
                }
            }
        }
    }
}
