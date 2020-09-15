using MapKit;
using ObjCRuntime;
using Taxi.MobileApp.iOS.Renderers;
using Taxi.MobileApp.Models;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;

[assembly: ExportRenderer(typeof(TaxiMap), typeof(CustomiOSMapRenderer))]

namespace Taxi.MobileApp.iOS.Renderers
{
    public class CustomiOSMapRenderer : MapRenderer
    {
        protected override MKAnnotationView GetViewForAnnotation(
            MKMapView mapView,
            IMKAnnotation annotation)
        {
            if (Runtime.GetNSObject(annotation.Handle) is MKUserLocation)
                return (MKAnnotationView) null;
            MKAnnotationView mapPin = mapView.DequeueReusableAnnotation("defaultPin");
            if (mapPin == null)
            {
                mapPin = (MKAnnotationView) new MKPinAnnotationView(annotation, "defaultPin");
                mapPin.Annotation = annotation;
                mapPin.CanShowCallout = false;
                mapPin.Image = annotation.GetTitle() == "Available"
                    ? UIImage.FromFile("taxi_available.png")
                    : UIImage.FromFile("taxi_unavailable.png");
            }
            
            this.AttachGestureToPin(mapPin, annotation);
            return mapPin;
        }
    }
}