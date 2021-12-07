using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Teacher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SessionListforTeachers : ContentPage
    {
        public SessionListforTeachers()
        {
            InitializeComponent();
        }

        private void backImageButton_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new TeacherDashboard());
        }

    }
}