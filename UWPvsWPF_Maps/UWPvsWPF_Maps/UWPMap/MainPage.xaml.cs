using System;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPMap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            MapInit();

            MapModes();

            //SetLanguage();

            AddPushPins();

            AddMapPolygon();
        }

        void MapModes()
        {
            /*
            link: https://docs.microsoft.com/en-us/windows/uwp/maps-and-location/display-maps
           Use a map control to show rich and customizable map data in your app. A map control can display road maps, aerial, 3D, views, directions, search results, and traffic. 
           On a map, you can display the user's location, directions, and points of interest. 
           A map can also show aerial 3D views, Streetside views, traffic, transit, and local businesses.
            */
        }

        void SetLanguage()
        {
            //https://stackoverflow.com/questions/42938755/display-language-for-mapcontrol-in-uwp?rq=1
            throw new NotImplementedException("Not possible.");
        }

        void AddPushPins()
        {
            var MyLandmarks = new List<MapElement>();

            BasicGeoposition snPosition = new BasicGeoposition { Latitude = 47.620, Longitude = -122.349 };
            Geopoint snPoint = new Geopoint(snPosition);

            var spaceNeedleIcon = new MapIcon
            {
                Location = snPoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = "Pin 1"
            };

            spaceNeedleIcon.Tag = "Tag Pin 1";
            MyLandmarks.Add(spaceNeedleIcon);

            BasicGeoposition snPosition2 = new BasicGeoposition { Latitude = 41.622, Longitude = -122.340 };
            Geopoint snPoint2 = new Geopoint(snPosition2);
            var spaceNeedleIcon2 = new MapIcon
            {
                Location = snPoint2,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = "Pin 3"
            };

            MyLandmarks.Add(spaceNeedleIcon2);

            //
            BasicGeoposition snPosition3 = new BasicGeoposition { Latitude = 47.620, Longitude = -117.549 };
            Geopoint snPoint3 = new Geopoint(snPosition3);
            var spaceNeedleIcon3 = new MapIcon
            {
                Location = snPoint3,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = "Pin 2"
            };

            MyLandmarks.Add(spaceNeedleIcon3);


            BasicGeoposition snPosition4 = new BasicGeoposition { Latitude = 41.622, Longitude = -117.549 };
            Geopoint snPoint4 = new Geopoint(snPosition4);
            var spaceNeedleIcon4 = new MapIcon
            {
                Location = snPoint4,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = "Pin 4"
            };

            //MyLandmarks.Add(spaceNeedleIcon4);
            //

            var LandmarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLandmarks
            };

            var MyLandmarks2 = new List<MapElement>();
            MyLandmarks2.Add(spaceNeedleIcon4);
            var LandmarksLayer2 = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLandmarks2
            };

            // MyLandmarks.Add(spaceNeedleIcon4);
            LandmarksLayer.MapElementClick += MapElement_ClickEvent;
            myMap.Layers.Add(LandmarksLayer);
            LandmarksLayer2.MapElementClick += MapElement_ClickEvent2;
            myMap.Layers.Add(LandmarksLayer2);
        }

        void AddMapPolygon()
        {

            var mapPolygon = new MapPolygon
            {
                Path = new Geopath(new List<BasicGeoposition> {
                    new BasicGeoposition() {Latitude = 47.620, Longitude = -122.349 },
                    new BasicGeoposition() {Latitude = 47.620, Longitude = -117.549 },
                    new BasicGeoposition() {Latitude = 41.622, Longitude = -117.549 },
                    new BasicGeoposition() {Latitude = 41.622, Longitude = -122.340},
                }),
                ZIndex = 1,
                FillColor = Colors.Red,
                StrokeColor = Colors.Blue,
                StrokeThickness = 3,
                StrokeDashed = false,

            };

            // Add MapPolygon to a layer on the map control.
            var MyHighlights = new List<MapElement>();

            MyHighlights.Add(mapPolygon);

            var HighlightsLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyHighlights
            };

            myMap.Layers.Add(HighlightsLayer);
        }

        async void MapElement_ClickEvent(object sendeer, MapElementsLayerClickEventArgs e)
        {
            var dialog = new MessageDialog("Pushpin 1, 2 or 3 was clicked!");
            await dialog.ShowAsync();
        }

        async void MapElement_ClickEvent2(object sendeer, MapElementsLayerClickEventArgs e)
        {
            var dialog = new MessageDialog("Pushpin 4 was clicked!");
            await dialog.ShowAsync();
        }

        void MapInit()
        {
            BasicGeoposition snPosition = new BasicGeoposition { Latitude = 47.620, Longitude = -122.349 };
            Geopoint snPoint = new Geopoint(snPosition);

            myMap.Center = snPoint;
            myMap.ZoomLevel = 6;
        }
    }
}
