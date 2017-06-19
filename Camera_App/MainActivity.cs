using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Provider;
using System;

namespace Camera_App
{
    [Activity(Label = "Camera_App", MainLauncher = true)]
    public class MainActivity : Activity
    {

        ImageView imageView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            int a = 1;

            a += 1;
            // Set our view from the "main" layout resource

            SetContentView (Resource.Layout.Main);

            var btnSnap = FindViewById<Button>(Resource.Id.btnSnap);
            imageView = FindViewById<ImageView>(Resource.Id.imgView);

            btnSnap.Click += BtnSnap_Click;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            imageView.SetImageBitmap(bitmap);
        }

        private void BtnSnap_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
    }
}

