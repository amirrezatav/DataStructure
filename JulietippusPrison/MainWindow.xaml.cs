using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace JulietippusPrison
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public delegate void UpdateCorridor(Person ps);
    public delegate void UpdateGroundFloor(Person ps);
    public delegate void UpdateYard(Person ps , bool mode);
    public delegate void UpdatePower(bool mode);


    public partial class MainWindow : Window
    {
        public static UpdateCorridor uc;
        public static UpdateGroundFloor ug;
        public static UpdateYard uy;
        public static UpdatePower pw;
        JulietippusArray julietippusArray;
        JulietippusLinkLiest julietippusLinkLiest;
        int Mode;
        Thread th;

        public MainWindow(int mode)
        {
            InitializeComponent();
            uc += UpdateCorridor_Handle;
            ug += UpdateGroundFloorr_Handle;
            uy += UpdateYard_Handle;
            pw += Powre_Handle;
            Mode = mode;
        }
        void Powre_Handle(bool flag)
        {
            this.Dispatcher.Invoke(() =>
            {
                var bc = new BrushConverter();

                if (flag)
                    CorridorList.Background = new SolidColorBrush(Color.FromArgb(100, 0, 110, 65));
                else
                    CorridorList.Background = (Brush)bc.ConvertFrom("#FF006E41");
            });
        }
        void UpdateCorridor_Handle(Person ps)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (CorridorList.Items.Count > (Mode == 0 ? julietippusArray.CorridorCapacity : julietippusLinkLiest.CorridorCapacity))
                    throw new Exception();

                if (ps == null && CorridorList.Items.Count != 0)
                    CorridorList.Items.RemoveAt(0);
                else if (ps != null)
                    CorridorList.Items.Add(new ListBoxItem().Content = ps.id.ToString());

                if (CorridorList.Items.Count != 0)
                    Rec.Text = "  در حال دریافت غذا  " + CorridorList.Items[0].ToString()  ;
                else
                    if(!(Mode == 0 ? julietippusArray.Power : julietippusLinkLiest.Power))
                        Rec.Text = "برق رفته است و ترسو ها به بالای راهرو رفته اند";
                    else
                        Rec.Text = "همیچ گرسنه ای وجود ندارد.";
            });
        }
        void UpdateGroundFloorr_Handle(Person ps)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (ps == null && GroundFloorList.Items.Count != 0)
                    GroundFloorList.Items.RemoveAt(0);
                else if (ps != null)
                    GroundFloorList.Items.Add(new ListBoxItem().Content = ps.id.ToString());
            });
        }
        void UpdateYard_Handle(Person ps , bool flag)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (!flag && YardList.Items.Count != 0)
                {
                    int a = YardList.Items.IndexOf(new ListBoxItem().Content = ps.id.ToString());
                    YardList.Items.RemoveAt(a);

                }
                else if(flag)
                    YardList.Items.Add(new ListBoxItem().Content = ps.id.ToString());
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Mode == 0)
                {
                    julietippusArray.Add_Person(julietippusArray.FullSize);
                    th = new Thread(new ThreadStart(() => { julietippusArray.EnterPerson(julietippusArray.FullSize - 1); }));
                    th.SetApartmentState(ApartmentState.STA);
                    th.IsBackground = true;
                    th.Start();
                }
                else
                {
                    julietippusLinkLiest.Add_Person(julietippusLinkLiest.FullSize);
                    th = new Thread(new ThreadStart(() => { julietippusLinkLiest.EnterPerson(julietippusArray.FullSize - 1); }));
                    th.SetApartmentState(ApartmentState.STA);
                    th.IsBackground = true;
                    th.Start();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("امکان افزودن زندانی نیست");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Start.IsEnabled = false;
            this.Cursor = Cursors.Wait;
            try
            {
                string[] rect = TBRcevTime.Text.Split(':'); 
                string[] PowerOfft = TBPowerOff.Text.Split(':');
                string[] PowerOffDuringt = TBPowerOffDuring.Text.Split(':');
                string[] FoodTimet = TBFoodTime.Text.Split(':');
                if (Mode == 0)
                {
                    julietippusArray = new JulietippusArray(
                        Convert.ToInt32(TBJulietippusDefaultNumbers.Text)
                        , Convert.ToInt32(TBPrisonCapacity.Text)
                        , Convert.ToInt32(TBGroundFloorCapacity.Text)
                        , new TimeSpan(Convert.ToInt32(rect[0]), Convert.ToInt32(rect[1]), Convert.ToInt32(rect[2]))
                        , new TimeSpan(Convert.ToInt32(PowerOfft[0]), Convert.ToInt32(PowerOfft[1]), Convert.ToInt32(PowerOfft[2]))
                        , new TimeSpan(Convert.ToInt32(PowerOffDuringt[0]), Convert.ToInt32(PowerOffDuringt[1]), Convert.ToInt32(PowerOffDuringt[2]))
                        , new TimeSpan(Convert.ToInt32(FoodTimet[0]), Convert.ToInt32(FoodTimet[1]), Convert.ToInt32(FoodTimet[2]))
                        );
                    th = new Thread(new ThreadStart(() => { julietippusArray.start(); }));
                    th.SetApartmentState(ApartmentState.STA);
                    th.IsBackground = true;
                    th.Start();
                }
                else
                {
                    julietippusLinkLiest = new JulietippusLinkLiest(
                        Convert.ToInt32(TBJulietippusDefaultNumbers.Text)
                        , Convert.ToInt32(TBPrisonCapacity.Text)
                        , Convert.ToInt32(TBGroundFloorCapacity.Text)
                        , new TimeSpan(Convert.ToInt32(rect[0]), Convert.ToInt32(rect[1]), Convert.ToInt32(rect[2]))
                        , new TimeSpan(Convert.ToInt32(PowerOfft[0]), Convert.ToInt32(PowerOfft[1]), Convert.ToInt32(PowerOfft[2]))
                        , new TimeSpan(Convert.ToInt32(PowerOffDuringt[0]), Convert.ToInt32(PowerOffDuringt[1]), Convert.ToInt32(PowerOffDuringt[2]))
                        , new TimeSpan(Convert.ToInt32(FoodTimet[0]), Convert.ToInt32(FoodTimet[1]), Convert.ToInt32(FoodTimet[2]))
                        );
                    th = new Thread(new ThreadStart(() => { julietippusLinkLiest.start(); }));
                    th.SetApartmentState(ApartmentState.STA);
                    th.IsBackground = true;
                    th.Start();
                }
                Grid_StartUp.Visibility = Visibility.Collapsed;
                Grid_Main.Visibility = Visibility.Visible;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
                Start.IsEnabled = true;
            }
        }
    }
}
