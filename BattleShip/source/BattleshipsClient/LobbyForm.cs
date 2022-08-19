using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleshipsLibrary;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.UDP;

namespace BattleshipsClient
{
    public partial class LobbyForm : Form
    {
        public string ServerIp { get; set; }
        public int ServerPort { get; set; }
        public string ServerName { get; set; }
        public string PlayerName { get; set; }

        public LobbyForm(ConnectResponse response)
        {
            InitializeComponent();
            MinimumSize = MaximumSize = Size;

            
            NetworkComms.AppendGlobalConnectionCloseHandler(ConnectionShutdownDelegate);
            NetworkComms.AppendGlobalIncomingPacketHandler<ChatMessage>("DisplayChatMessage", DisplayChatMessageDelegatePointer);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("ChallengeAcceptRequest", ChallengeAcceptRequestDelegatePointer);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("ChallengeFailed", ChallengeFailedDelegatePointer);
            NetworkComms.AppendGlobalIncomingPacketHandler<Client>("ChallengeAccepted", ChallengeAcceptedDelegatePointer);
            NetworkComms.AppendGlobalIncomingPacketHandler<List<Client>>("UpdateListInfo", UpdateListInfoDelegatePointer);

            
            lblServerIp.Text = ServerName = response.ServerName;
            lblPlayers.Text = response.ConnectedClients.Count.ToString("00");

            
            foreach (var client in response.ConnectedClients)
            {
                listPlayers.Items.Add(client.Name);
            }
        }

        #region metode

        
        private void ConnectionShutdownDelegate(Connection connection)
        {
            MessageBox.Show($"Conexiune la server {ServerName} s-a pierdut!");
            NetworkComms.Shutdown();
            Application.Exit();
        }

        
        private void UpdateListInfoDelegatePointer(PacketHeader packetheader, Connection connection, List<Client> clients)
        {
            Invoke(new UpdateListDelegate(UpdateList), clients);
        }

        
        private delegate void UpdateListDelegate(List<Client> clients);

        
        private void UpdateList(List<Client> clients)
        {
            lblPlayers.Text = clients.Count.ToString("00");

            listPlayers.Items.Clear();
            foreach (var client in clients)
            {
                listPlayers.Items.Add(client.Name);
            }
        }

       
        private void ChallengeAcceptedDelegatePointer(PacketHeader packetheader, Connection connection, Client enemy)
        {
            Invoke(new OpenGameFormDelegate(OpenGameForm), ServerIp, ServerPort, enemy);
        }

        
        private delegate void OpenGameFormDelegate(string serverIp, int serverPort, Client enemy);

        
        private void OpenGameForm(string serverIp, int serverPort, Client enemy)
        {
            Hide();

            GameForm gameForm = new GameForm
            {
                ServerIp = serverIp,
                ServerPort = serverPort,
                EnemyIp = enemy.Ip,
                EnemyPort = enemy.Port,
                EnemyName = enemy.Name,
                PlayerName = PlayerName
            };

            gameForm.Show();
        }

        
        private void ChallengeAcceptRequestDelegatePointer(PacketHeader packetheader, Connection connection, string name)
        {
            var response = MessageBox.Show($"Utilizatorul {name} Te-a provocat să joci, accepți?", "O provocare de jucat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (response == DialogResult.Yes)
            {
                NetworkComms.SendObject("ChallengeAcceptInfo", ServerIp, ServerPort, true);
            }
            else
            {
                NetworkComms.SendObject("ChallengeAcceptInfo", ServerIp, ServerPort, false);
            }
        }

        
        private void ChallengeFailedDelegatePointer(PacketHeader packetheader, Connection connection, string text)
        {
            MessageBox.Show(text, "Inchide", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
        private void DisplayChatMessageDelegatePointer(PacketHeader packetheader, Connection connection, ChatMessage message)
        {
            Invoke(new DisplayToChatDelegate(DisplayToChat), message);
        }

        
        private delegate void DisplayToChatDelegate(ChatMessage message);

        
        private void DisplayToChat(ChatMessage message)
        {
            rtbChat.Text += $"\n{message}";
        }

        
        private void Challenge()
        {
            string name = listPlayers.GetItemText(listPlayers.SelectedItem);

            if (name == PlayerName)
            {
                MessageBox.Show("Nu te poti provoca sa joci singur", "Inchide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var response = MessageBox.Show($"Vrei să provoci jucătorul {name} să joace?", "Provoaca",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (response == DialogResult.Yes)
                {
                    NetworkComms.SendObject("ChallengeRequest", ServerIp, ServerPort, name);
                }
            }
        }

        #endregion

        #region Form

        
        private void txtMessage_Click(object sender, EventArgs e)   => AcceptButton = btnSend;
        private void listPlayers_Click(object sender, EventArgs e)  => AcceptButton = btnChallenge;

        
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                ChatMessage message = new ChatMessage(PlayerName, txtMessage.Text);
                NetworkComms.SendObject("BroadcastChatMessage", ServerIp, ServerPort, message);
                txtMessage.Clear();
            }
        }


        
        private void listPlayers_DoubleClick(object sender, EventArgs e)    => Challenge();
        private void btnChallenge_Click(object sender, EventArgs e)         => Challenge();

        
        private void LobbyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            NetworkComms.SendObject("Disconnect", ServerIp, ServerPort, "");
            NetworkComms.Shutdown();
            Application.Exit();
        }

        #endregion

        
    }
}
