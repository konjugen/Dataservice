using System;
using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using Microsoft.WindowsAzure.MobileServices;
using dataservices.DTO;
using System.Collections.Generic;
using dataservices.Adapter;

namespace dataservices
{
    [Activity (MainLauncher = true, 
               Icon="@drawable/ic_launcher", Label="@string/app_name",
               Theme="@style/AppTheme")]
    public class MainActivity : Activity
    {
        private MobileServiceClient client;
        private IMobileServiceTable<Category> categoryTable;

        public List<Category> categoryItemList = new List<Category>();

        private CategoryAdapter adapter;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Activity_To_Do);

            try
            {

                CurrentPlatform.Init();
                client = new MobileServiceClient(
                    Constants.ApplicationURL,
                    Constants.ApplicationKey);

                categoryTable = client.GetTable<Category>();

                await RefreshItemsFromTableAsync();

            }
            catch (Java.Net.MalformedURLException)
            {
                CreateAndShowDialog(new Exception("There was an error creating the Mobile Service. Verify the URL"), "Error");
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }

        }

        async Task RefreshItemsFromTableAsync()
        {

            try
            {
                categoryItemList = await categoryTable.Where(item => item.IsDaily == true).ToListAsync();
                adapter.Clear();

                foreach (Category current in categoryItemList)
                    adapter.Add(current);
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }
        }

        void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }
        void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}


