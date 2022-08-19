using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BattleshipsLibrary;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;

namespace BattleshipsServer
{
    class Program
    {    
        public static List<Client> Clients = new List<Client>();
        public static List<Game> Games = new List<Game>();
        public static string ServerName = "localhost";

        private static int _gamesCountId = 0;

        static void Main(string[] args)
        {
            
            if (args.Length == 1) ServerName = args[0];

            Console.Title = $"{ServerName} | BattleShips Server";

            
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("ConnectUser", ConnectUser);
            NetworkComms.AppendGlobalIncomingPacketHandler<GameStartRequest>("GameStartRequest", GameStartRequest);
            NetworkComms.AppendGlobalIncomingPacketHandler<GameFireInfo>("GameFireInfo", GameFireInfo);
            NetworkComms.AppendGlobalIncomingPacketHandler<ChatMessage>("BroadcastChatMessage", BroadcastChatMessageDelgatePointer);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("ChallengeRequest", ChallengeRequestDelgatePointer);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("Disconnect", DisconnectDelgatePointer);
            //NetworkComms.AppendGlobalConnectionCloseHandler(ConnectionShutdownDelegate);

            // Adrese ip pc
            Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, 20123));

            //Lista adrese
            Console.WriteLine($"Serverul așteaptă o conexiune TCP la următoarele adrese:");
            foreach (var endPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
            {
                var localEndPoint = (IPEndPoint) endPoint;
                Console.WriteLine(" -> {0} : {1}", localEndPoint.Address, localEndPoint.Port);
            }

            //Inchidere dupa apasarea * taste
            Console.WriteLine();
            Console.WriteLine("Apăsați orice tastă pentru a închide serverul");
            Console.WriteLine("-----------------------------------\n");
            Console.ReadKey(true);

            //Inchidere proces conectare
            NetworkComms.Shutdown();
        }

        //Deconectarea clientului la cerere
        private static void DisconnectDelgatePointer(PacketHeader packetheader, Connection connection, string enemyName)
        {
            //Ip clientului
            IPEndPoint clientEndPoint = (IPEndPoint)connection.ConnectionInfo.RemoteEndPoint;

            Client enemy = Clients.Find(x => x.Name == enemyName);
            Client client = Clients.Find(x => x.Ip == clientEndPoint.Address.ToString() && x.Port == clientEndPoint.Port);

            
            if (enemy != null) NetworkComms.SendObject("Disconnect", enemy.Ip, enemy.Port, true);

            Console.WriteLine($"({client.Name}) s-a deconectat!");

            Game game = Games.Find(x => x.HasClient(enemy) || x.HasClient(client));

            
            if (game != null) Games.Remove(game);
            Clients.Remove(client);

            foreach (Client c in Clients)
            {
                NetworkComms.SendObject("UpdateListInfo", c.Ip, c.Port, Clients);
            }
        }

        //Trimite cerere de a provoca un jucator
        private static void ChallengeRequestDelgatePointer(PacketHeader packetheader, Connection connection, string name)
        {
            //Invitatie
            Client enemy = Clients.Find(x => x.Name == name);
            bool isEnemyInGame = Games.Any(x => x.HasClient(enemy));

            IPEndPoint clientEndPoint = (IPEndPoint) connection.ConnectionInfo.RemoteEndPoint;

            //Dacă există și nu este în joc
            if (enemy != null && !isEnemyInGame)
            {
                
                Client player = Clients.Find(x => x.Ip == clientEndPoint.Address.ToString() && x.Port == clientEndPoint.Port);

                Console.WriteLine($"({player.Name}) invită utilizatorul {enemy.Name} să se joace.");
                
                try
                {
                    
                    bool response = NetworkComms.SendReceiveObject<string, bool>("ChallengeAcceptRequest", enemy.Ip, enemy.Port, "ChallengeAcceptInfo", 20000, player.Name);

                    
                    if (response)
                    {
                        Console.WriteLine($"({enemy.Name}) a acceptat provocarea de la {player.Name}");
                        NetworkComms.SendObject("ChallengeAccepted", clientEndPoint.Address.ToString(), clientEndPoint.Port, enemy);
                        NetworkComms.SendObject("ChallengeAccepted", enemy.Ip, enemy.Port, player);
                    }
                    
                    else
                    {
                        Console.WriteLine($"({enemy.Name}) a refuzat provocarea de la {player.Name}");
                        NetworkComms.SendObject("ChallengeFailed", clientEndPoint.Address.ToString(), clientEndPoint.Port, $"A respins cererea dvs. de joc!");
                    }
                }
                
                catch
                {
                    Console.WriteLine($"({enemy.Name}) nu răspunde la cererea de la {player.Name}");
                    NetworkComms.SendObject("ChallengeFailed", clientEndPoint.Address.ToString(), clientEndPoint.Port,$"Utilizatorul nu a raspuns la cererea dumneavoastră la timp!");
                }
            }

            
            if (isEnemyInGame)
            {
                NetworkComms.SendObject("ChallengeFailed", clientEndPoint.Address.ToString(), clientEndPoint.Port, $"Utilizatorul {name} în prezent concurează cu altcineva!");
            }

            
            if (enemy == null)
            {
                NetworkComms.SendObject("ChallengeFailed", clientEndPoint.Address.ToString(), clientEndPoint.Port, $"Nu am putut găsi utilizatorul!");

            }
        }

        
        private static void BroadcastChatMessageDelgatePointer(PacketHeader packetheader, Connection connection, ChatMessage message)
        {

            foreach (Client client in Clients)
            {
                NetworkComms.SendObject("DisplayChatMessage", client.Ip, client.Port, message);
            }

            Console.WriteLine($"({message.PlayerName}) scrie: {message.Message}");
        }

        
        private static void GameFireInfo(PacketHeader packetheader, Connection connection, GameFireInfo gfi)
        {
            Game game = Games.Find(x => x.Id == gfi.GameId);

            IPEndPoint clientEndPoint = (IPEndPoint) connection.ConnectionInfo.RemoteEndPoint;

            if (game.Client1.Ip == clientEndPoint.Address.ToString() && game.Client1.Port == clientEndPoint.Port)
            {
                Console.WriteLine($"(Joc #{game.Id}) Utilizator {game.Client1.Name} trage");
                game.FireOnClient2(gfi.Position);
            }

            if (game.Client2.Ip == clientEndPoint.Address.ToString() && game.Client2.Port == clientEndPoint.Port)
            {
                Console.WriteLine($"(Joc #{game.Id}) Utilizator {game.Client2.Name} trage");
                game.FireOnClient1(gfi.Position);
            }

            game.ResetIfEnd();
        }

        
        private static void GameStartRequest(PacketHeader packetheader, Connection connection, GameStartRequest gsr)
        {
            IPEndPoint clientEndPoint = (IPEndPoint)connection.ConnectionInfo.RemoteEndPoint;
            Client client = Clients.Find(x => x.Ip == clientEndPoint.Address.ToString() && x.Port == clientEndPoint.Port);
            Client enemyClient = Clients.Find(x => x.Ip == gsr.EnemyIp && x.Port == gsr.EnemyPort);
            Game game = Games.Find(x => x.HasClient(enemyClient));

            
            if (game != null && client != game.Client1)
            {
                game.Client2 = client;
                game.Client2ShipPositions = gsr.ShipsPositions;

                game.StartGame(_gamesCountId);

                _gamesCountId++;
            }
            
            else
            {
                Game g = new Game
                {
                    Client1 = client,
                    Client1ShipPositions = gsr.ShipsPositions
                };
                Games.Add(g);
                Console.WriteLine($"(Jocul #{g.Id}) intre {client.Name} si {enemyClient.Name} a inceput!");
            }

            Console.WriteLine($"({client.Name}) este gata să se joace cu utilizatorul {enemyClient.Name}");

        }

        
        private static void ConnectUser(PacketHeader packetheader, Connection connection, string name)
        {
            IPEndPoint clientEndPoint = (IPEndPoint)connection.ConnectionInfo.RemoteEndPoint;

            
            if (Clients.Any(x => x.Name == name))
            {
                string reason = string.Format($"Numele de utilizator {name} este deja ocupat!");
                
                ConnectResponse response = new ConnectResponse(ResponseType.Rejected, ServerName, reason);
                connection.SendObject("ConnectInfo", response);

                Console.WriteLine($"{name} nu s-a putut conecta la server din cauza: {reason}");

            }
            
            else
            {
                Clients.Add(new Client(name, clientEndPoint.Address.ToString(), clientEndPoint.Port));

                ConnectResponse response = new ConnectResponse(ResponseType.Accepted, ServerName, Clients);
                connection.SendObject("ConnectInfo", response);

                Console.WriteLine($"({name}) conectat la server (total  {Clients.Count} jucatori)");
            }

            
            foreach (Client client in Clients)
            {
                NetworkComms.SendObject("UpdateListInfo", client.Ip, client.Port, Clients);
            }
        }
    }
}