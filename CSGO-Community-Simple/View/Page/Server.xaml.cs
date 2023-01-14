using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;

namespace CSGO_Community_Simple
{
    /// <summary>
    /// Server.xaml 的交互逻辑
    /// </summary>
    public partial class Server : UiPage
    {
        public Server()
        {
            InitializeComponent();
            Loaded += Server_Loaded;
        }

        private void Server_Loaded(object sender, RoutedEventArgs e)
        {
            //BlurEffect blur = new BlurEffect();
            //blur.Radius = 10;
            //card.Effect = blur;

        }

        private void Customized_btn(object sender, RoutedEventArgs e)
        {
            

            var psi = new ProcessStartInfo
            {
                FileName = "https://qm.qq.com/cgi-bin/qm/qr?k=wh3jnjx_UX42aqeo0AaS_KTdM8HfA7S_&jump_from=webapi&authKey=ResRsyLrzZ2nawe9suo8LtP9W2Lp5a/nSwGweyZCK6yF5UanV6L/TlWBNj9X2VaB",
                UseShellExecute = true
            };
            Process.Start(psi);

        }
    }
}
