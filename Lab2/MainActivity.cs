using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using static Android.Preferences.Preference;

namespace Lab2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    
    class ViewsContainer : LinearLayout
    {
        private int viewsCount = 0;
        public ViewsContainer(Context context) : base(context)
        {
        }

        public void IncrementViews()
        {
            TextView textView = new TextView(Context);
            textView.SetText(viewsCount.ToString(),
                TextView.BufferType.Normal);
            viewsCount++;
            AddView(textView);
        }

        protected override IParcelable OnSaveInstanceState()
        {
            SavedState state = (SavedState)base.OnSaveInstanceState();
            state.ViewsCount = viewsCount;
            return state;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if (!(state is SavedState))
            {
                base.OnRestoreInstanceState(state);
                return;
            }
            SavedState s = (SavedState)state;
            base.OnRestoreInstanceState(state);

            for (int i = 0 ; i < viewsCount; i++)
            {
                IncrementViews();
            }
        }
    }

    public class SavedState : BaseSavedState
    {
        public int ViewsCount { get; set; }

        public SavedState(Parcel State) : base(State)
        {
            ViewsCount = State.ReadInt();
        }

        public override void WriteToParcel(Parcel dest,
            [GeneratedEnum] ParcelableWriteFlags flags)
        {
            base.WriteToParcel(dest, flags);
            dest.WriteInt(ViewsCount);
        }
    }

    public class MainActivity : AppCompatActivity
    {
        private ViewsContainer container;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += Button_Click;

            container = FindViewById<ViewsContainer>(Resource.Id.container);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            container.IncrementViews();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}