using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;

namespace ASPGMaps.admin
{
    public partial class studentlocations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Here I used ZDNU Location as Main Location and Lat Long is : -17.731651, 31.021174
                GLatLng mainLocation = new GLatLng(-17.836050, 31.005899);
                GMap1.setCenter(mainLocation, 15);

                XPinLetter xpinLetter = new XPinLetter(PinShapes.pin_star, "I", Color.Blue, Color.White, Color.Chocolate);
                GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));

                List<HotelMaster> hotels = new List<HotelMaster>();
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    hotels = dc.HotelMasters.Where(a => a.HotelArea.Equals("Recruit")).ToList();
                }

                PinIcon p;
                GMarker gm;
                GInfoWindow win;
                foreach (var i in hotels)
                {
                    p = new PinIcon(PinIcons.home, Color.Cyan);
                    gm = new GMarker(new GLatLng(Convert.ToDouble(i.LocLat), Convert.ToDouble(i.LocLong)),
                        new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));

                    win = new GInfoWindow(gm, i.HotelName, GListener.Event.mouseover);
                    GMap1.Add(win);
                }
            }
    }
    }
}