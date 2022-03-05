using Connect4.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Connect4.Hubs
{
    public class GameHub : Hub
    {
        //Track each group/game

        internal static Dictionary<int, List<string>> Games = new Dictionary<int, List<string>>();
        public override async Task OnConnectedAsync()
        {
            //Find an available game
            var gameID = getAvailableGame();
            if (gameID == -1)
            {
                //Create new game
                gameID = Games.Count() + 1;
                Games.Add(gameID, new List<string> { Context.ConnectionId});
            }
            JoinGame(gameID);
        }

        public int getAvailableGame()
        {
            var foundGame = -1;
            Games.Keys.ToList().ForEach(gameID => {
                var players = Games[gameID];
                if (foundGame == -1 && players.Count() < 2)
                {
                    Games[gameID].Add(Context.ConnectionId);
                    foundGame = gameID;
                }
            });
            return foundGame;
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connID = Context.ConnectionId;
            Games.Keys.ToList().ForEach(gameID =>
            {
                var players = Games[gameID];
                var connID = Context.ConnectionId;

                if (players.Contains(connID))
                {
                    Games[gameID].Remove(connID);
                    LeaveGame(gameID);
                }
            });
            await base.OnDisconnectedAsync(exception);
        }
        public async void JoinGame(int gameID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameID.ToString());
            await Clients.Group(gameID.ToString()).SendAsync("PlayerConnect", $"(Game: {gameID}){Context.ConnectionId} has joined the game. (Players: {Games[gameID].Count()})");
        }
        public async void LeaveGame(int gameID)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameID.ToString());
            await Clients.Group(gameID.ToString()).SendAsync("PlayerDisconnect", $"(Game: {gameID}){Context.ConnectionId} has left the game. (Players: {Games[gameID].Count()})");
        }
    }
}
