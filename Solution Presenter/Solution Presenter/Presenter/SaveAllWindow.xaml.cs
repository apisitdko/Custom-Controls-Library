﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CustomControls
{
    public partial class SaveAllWindow : Window
    {
        public SaveAllWindow()
        {
            InitializeComponent();
            DataContext = this;

            TitleList = new ObservableCollection<string>();
            DirtySolutionName = null;
            Result = MessageBoxResult.Cancel;

            Loaded += OnLoaded;
        }

        protected virtual void OnLoaded(object sender, EventArgs e)
        {
            Title = Owner.Title;
            Icon = Owner.Icon;
        }

        public ObservableCollection<string> TitleList { get; private set; }
        public string DirtySolutionName { get; set; }
        public MessageBoxResult Result { get; private set; }

        public string SaveText 
        {
            get
            {
                string Text = "";
                string TabText = "";

                if (DirtySolutionName != null)
                {
                    Text += DirtySolutionName;
                    Text += "*";
                    TabText = "  ";
                }

                foreach (string Title in TitleList)
                {
                    if (Text.Length > 0)
                        Text += "\r\n";

                    Text += TabText + Title;
                }

                return Text;
            }
        }

        private void OnYes(object sender, ExecutedRoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            Close();
        }

        private void OnNo(object sender, ExecutedRoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            Close();
        }

        private void OnCancel(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
