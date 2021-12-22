using FinalProject_IOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject_IOS.Views.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GradingGridPage : ContentPage
    {
        Tutoring t = new Tutoring();
        FirebaseHelper f = new FirebaseHelper();
        public GradingGridPage(Tutoring tutor)
        {
            InitializeComponent();
            t.tutorId = tutor.tutorId;
            t.tutoringId = tutor.tutoringId;
            t.date = tutor.date;
            t.firstName = tutor.firstName;
            t.feedback = tutor.feedback;
            t.lasttName = tutor.lasttName;
            t.startTime = tutor.startTime;
            t.endTime = tutor.endTime;
            
        }

        private void GoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AssignTutorsPage());
        }

        private async void GradeSession_Clicked(object sender, EventArgs e)
        {

            if ((Punctuality.Text == null || Punctuality.Text == "") || (Helpfulness.Text == null || Helpfulness.Text == "") || (Respect.Text == null || Respect.Text == "") || (Seriousness.Text == null || Seriousness.Text == "") || (Commitment.Text == "" || Commitment.Text == null))
            {
                await DisplayAlert("Error!", "Can't submit due to incomplete fields", "OK");
            }
            else
            {


                double punctuality = double.Parse(Punctuality.Text);
                double helpfulness = double.Parse(Helpfulness.Text);
                double respect = double.Parse(Respect.Text);
                double seriousness = double.Parse(Seriousness.Text);
                double commitment = double.Parse(Commitment.Text);

                DateTime dtFrom = DateTime.Parse(t.startTime);
                DateTime dtTo = DateTime.Parse(t.endTime);

                int timeDiff = dtTo.Hour - dtFrom.Hour;


                if (punctuality > 10.0 || helpfulness > 10.0 || respect > 10.0 || seriousness > 10.0 || commitment > 10.0 || punctuality < 0.0 || helpfulness < 0.0 || respect < 0.0 || seriousness < 0.0 || commitment < 0.0)
                {
                    await DisplayAlert("Error!", "Incorrect range of number format", "OK");
                }
                else if (timeDiff % 3 != 0 && timeDiff % 5 != 0)
                {
                    await DisplayAlert("Error!", "Cannot grade because tutoring session didnt exceed 3 to 5 hours", "OK");
                }
                else
                {
                    string tutorId = t.tutorId;
                    string tutoringId = t.tutoringId;
                    string date = t.date;
                    string starttime = t.startTime;
                    string endTime = t.endTime;
                    string firstName = t.firstName;
                    string lasttName = t.lasttName;

                    double grade = punctuality + helpfulness + respect + seriousness + commitment;


                    var response = await DisplayAlert("Confirm grading", "Do you want to submit the grading?", "Yes", "No");

                    if (response)
                    {
                        string mark = "";
                        if (grade <= 10.0)
                        {
                            mark = "F";
                        }
                        if (10.0 < grade && grade <= 20.0)
                        {
                            mark = "E";
                        }
                        if (20.0 < grade && grade < 30.0)
                        {
                            mark = "D";
                        }
                        if (30.0 <= grade && grade < 40.0)
                        {
                            mark = "C";
                        }
                        if (40.0 <= grade && grade < 45.0)
                        {
                            mark = "B";
                        }
                        if (45.0 <= grade && grade <= 50)
                        {
                            mark = "A";
                        }

                        bool graded = await f.AddGrade(tutoringId, tutorId, firstName, lasttName, date, starttime, endTime, mark);
                    }
                }
            }
        }
    }
}