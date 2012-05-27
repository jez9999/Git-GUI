﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GG.Libraries;

namespace GG.UserControls
{
    /// <summary>
    /// Interaction logic for Panel.xaml
    /// </summary>
    public partial class Panel : UserControl
    {
        #region HeaderText property.
        /// <summary>
        /// The text to use for the header.
        /// </summary>
        public string HeaderText
        {
            get { return (string) GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public static DependencyProperty HeaderTextProperty =
            DependencyProperty.Register("HeaderText",
                                        typeof(string),
                                        typeof(Panel),
                                        new PropertyMetadata("Title", new PropertyChangedCallback(HeaderTextPropertyChanged)));

        private static void HeaderTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Panel;
            if (control != null)
            {
                control.HeaderText = (string) e.NewValue;
            }
        }
        #endregion

        public Panel()
        {
            InitializeComponent();
        }

        private void CommitMessagesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox myComboBox = UIHelper.FindChild<ComboBox>(this, "CommitMessagesComboBox");
            //this causes null reference exception since myCombox has all null values for some reason
            //System.Windows.Forms.Clipboard.SetText(myComboBox.Text);

            //this properly resets the combobox
            myComboBox.SelectedIndex = -1;
        }
    }
}
