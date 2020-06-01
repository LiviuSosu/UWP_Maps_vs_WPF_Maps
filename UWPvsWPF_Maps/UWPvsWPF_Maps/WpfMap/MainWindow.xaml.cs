using Microsoft.Maps.MapControl.WPF;
using System.Windows;
using System.Windows.Media;

namespace WpfMap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MapInit();

            MapModes();

            SetLanguage();

            AddPushPins();

            AddMapPolygon();
        }

        void MapModes()
        {
            /*
            link: https://docs.microsoft.com/en-us/previous-versions/bing/wpf-control/hh830432(v=msdn.10)
            Available modes: Aerial, AerialWithLabels and Road.
            */
        }

        void SetLanguage()
        {
            myMap.Culture = "en-en";
        }

        void AddPushPins()
        {
            Pushpin pushpin1 = new Pushpin();
            pushpin1.Location = new Location(47.620, -122.349);
            pushpin1.Content = "1";
            pushpin1.MouseLeftButtonDown += MouseRightButtonDownEvent;
            myMap.Children.Add(pushpin1);

            Pushpin pushpin2 = new Pushpin();
            pushpin2.Location = new Location(47.620, -117.549);
            pushpin2.Content = "2";
            pushpin2.MouseLeftButtonDown += MouseRightButtonDownEvent;
            myMap.Children.Add(pushpin2);

            Pushpin pushpin3 = new Pushpin();
            pushpin3.Location = new Location(41.622, -117.549);
            pushpin3.Content = "3";
            pushpin3.MouseLeftButtonDown += MouseRightButtonDownEvent;
            myMap.Children.Add(pushpin3);

            Pushpin pushpin4 = new Pushpin();
            pushpin4.Location = new Location(41.622, -122.340);
            pushpin4.Content = "4";
            pushpin4.MouseLeftButtonDown += MouseRightButtonDownEvent;
            myMap.Children.Add(pushpin4);
        }

        void AddMapPolygon()
        {
            MapPolygon polygon = new MapPolygon();
            polygon.Fill = new SolidColorBrush(Colors.Red);
            polygon.Stroke = new SolidColorBrush(Colors.Blue);
            polygon.StrokeThickness = 3;
            polygon.Opacity = 0.5;

            polygon.Locations = new LocationCollection() {
            new Location(47.620, -122.349),
            new Location(47.620,  -117.549),
            new Location(41.622, -117.549 ),
            new Location(41.622, -122.340)};

            myMap.Children.Add(polygon);
        }

        void MouseRightButtonDownEvent(object sender, RoutedEventArgs e)
        {
            if (sender is Pushpin pushpin)
            {
                MessageBox.Show(string.Format("Pushpin {0} was clicked", pushpin.Content.ToString()));
            }
        }
        void MapInit()
        {
            myMap.Center = new Location(47.620, -122.349);
            myMap.ZoomLevel = 6;
        }
    }
}
