using System;
using System.Windows.Forms;
using BattleshipsLibrary;
using NetworkCommsDotNet;

namespace BattleshipsClient
{
    public partial class LoginForm : Form
    {
        public static LobbyForm Lobby;
        
        public LoginForm()
        {
            InitializeComponent();
            MinimumSize = MaximumSize = Size;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                
                var response = NetworkComms.SendReceiveObject<string, ConnectResponse>("ConnectUser", txtIp.Text, (int) numPort.Value, "ConnectInfo", 10000, txtName.Text);

                
                if (response.ResponseType == ResponseType.Accepted)
                {
                    
                    Hide();

                    
                    Lobby = new LobbyForm(response)
                    {
                        ServerIp = txtIp.Text,
                        ServerPort = (int) numPort.Value,
                        PlayerName = txtName.Text
                    };
                    Lobby.Show();
                }
                
                else
                {
                   
                    MessageBox.Show(string.Format($"Server {response.ServerName} a refuzat să se conecteze, mesaj: {response.Response}"));
                }
            }
            catch
            {
                //Připojení se nezdařilo
                MessageBox.Show("Nu se poate conecta la server, verificați conexiunea și corectitudinea datelor introduse");
            }
        }
    }
}
