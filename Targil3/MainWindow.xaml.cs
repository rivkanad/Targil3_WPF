using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//Rina Greenboim 5948
//Rivka Nadell 6848

namespace Targil3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Host currentHost;//saves current host in comboBox
        public List<Host> hostsList;

        public MainWindow()
        {

            hostsList = new List<Host>()
            {
                new Host()
                {
                    HostName="משה",
                    Units=new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName="צימר מעולה",
                            NumRooms=4,
                            IsPool=false,
                            AllOrders= new List<DateTime>(),
                            Uris=new List<string>(){"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7ur_J7FbZQWRXd2OFnRyVLb26BucbC17K8GYEvnnYbtBa4sIj&s", "https://www.creme.co.il/gallery/151410813514_600x500.jpg"}
                        },
                        new HostingUnit()
                        {
                            UnitName="גליל",
                            NumRooms=1,
                            IsPool=true,
                            AllOrders= new List<DateTime>(),
                            Uris=new List<string>(){ "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7EaiMtaSq66a7ld_06bha6yt35XD1HT1uogbs7urdjoV00OYSDQ&s" }
                        },
                        new HostingUnit()
                        {
                            UnitName="יופי נופש",
                            NumRooms=6,
                            IsPool=true,
                            AllOrders=new List<DateTime>(),
                            Uris=new List<string>(){ "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRqixUqyYOz2FIbCasd3sOb6-8W9kzJ9NB8sIeI-Gww1238A3EZ&s", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRsUXkaDW-Nm9Ooly0QslEeEO2q70TA8BNlAnhLfdV7wCC2Cfuo&s", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTUqk7kJ_jRtzOCeSCdh8gIIR38GYI4TQd4TfVJiN2iSwJppkXb&s" }

                  }
                }
                },
                new Host()
                {
                    HostName="אפרים",
                    Units=new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName="בריכה ואוכל בצימר",
                            NumRooms=3,
                            IsPool=false,
                            AllOrders= new List<DateTime>(),
                            Uris=new List<string>(){"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRvS91YtkryR4ADl-Z2BYBu5YwBVwbbSgYsE-3cs3nXHSWpmFS_&s"}
                        },
                        new HostingUnit()
                        {
                            UnitName="להרגיש בנופש",
                            NumRooms=3,
                            IsPool=true,
                            AllOrders= new List<DateTime>(),
                            Uris=new List<string>(){ "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2jgQoiFVppa1FRAdmUlcyjoW0xZkIQWpwWI5x9pYq6d7i5Rx0Zg&s" }
                        }

                }
                },
                new Host()
                {
                    HostName="ברכה",
                    Units=new List<HostingUnit>()
                    {
                        new HostingUnit()
                        {
                            UnitName="כנרת",
                            NumRooms=5,
                            IsPool=true,
                            AllOrders= new List<DateTime>(),
                            Uris=new List<string>(){ "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSS2ROeguDIdpu9AZmtyQafq5QD2izM-jttRz8YwWS46CvCo8aV4w&s" }
                        },
                        new HostingUnit()
                        {
                            UnitName="נופשים בדרום",
                            NumRooms=2,
                            IsPool=true,
                            AllOrders= new List<DateTime>(),
                            Uris=new List<string>(){ "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROIRbYQcCD6mnOfwCeAtbWYsFJMGQIWpVUPxnkiRdVmMgllvAz&s" }
                        }

                },

                }
            };
            InitializeComponent();
            for (int i=0; i< 3; i++)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = hostsList[i].HostName;//sets combo box to name
                cbHostList.Items.Add(newItem);
            }//adds items to combo list box
            /*cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "Host Name";*/
            cbHostList.SelectedIndex = 0;
            InitializeHost(cbHostList.SelectedIndex);


        }

        private void InitializeHost(int index)
        {
            MainGrid.Children.RemoveRange(1, 3);
            currentHost = hostsList[index];
            UpGrid.DataContext = currentHost;
            for (int i = 0; i < currentHost.Units.Count; i++)
            {
                HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                MainGrid.Children.Add(a);
                Grid.SetRow(a, i + 1);
            }
        }

        private void CbHostList_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            InitializeHost(cbHostList.SelectedIndex);

        }
    }
}
