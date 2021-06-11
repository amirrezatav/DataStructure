using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JulietippusPrison
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                if(e.Args[0].Replace(" ", "").ToLower() == "-s" || e.Args[0].Replace(" ", "").ToLower() == "--stack")
                {
                    MainWindow mw = new MainWindow(0);
                    mw.Show();
                    MessageBox.Show("Open in Stack Mode ,you are pass : " + e.Args[0]);
                }
                else if (e.Args[0].Replace(" ", "").ToLower() == "-l" || e.Args[0].Replace(" ", "").ToLower() == "--linkedlist")
                {
                    MainWindow mw = new MainWindow(1);
                    mw.Show();
                    MessageBox.Show("Open in Linked List Mode ,you are pass : " + e.Args[0]);
                }
            }
            catch (Exception ex)
            {
                MainWindow mw = new MainWindow(0);
                mw.Show();
                MessageBox.Show("Open in default Mode (Stack) ,you are pass no standard argument : " + (e.Args.Length != 0 ? e.Args[0].Replace(" ", "").ToLower() : "Null") + "\n For Openning in Linked List mode pass -l or --likedlist and for open in stack mode pass -s or --stack.");
            }
        }
    }
}
