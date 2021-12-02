using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_CoursePage : ContentPage
    {
        public Add_CoursePage()
        {
            InitializeComponent();
        }

        private void AddTutoringSession_Clicked(object sender, EventArgs e)
        {
            /*Will Call in database instance and field names to 
             issue an insert*/
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CourseManagementPage());
        }
    }
}