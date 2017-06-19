using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Camera_App
{
    [Activity(Label = "GalleryView")]
    public class GalleryView : Activity
    {
        ImageView imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Main);

            imageView = FindViewById<ImageView>(Resource.Id.imgView);
            var btnGallery = FindViewById<Button>(Resource.Id.btnGallery);
            var btnCam = FindViewById<Button>(Resource.Id.btnSnap);

            btnCam.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            btnGallery.Click += delegate
            {
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(
                    Intent.CreateChooser(imageIntent, "Select Photo"), 0);
            };
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(resultCode == Result.Ok)
            {
                imageView.SetImageURI(data.Data);
            }
        }
    }
}