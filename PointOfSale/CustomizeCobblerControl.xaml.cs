/*
 * Author: K-State CIS 400 Faculty and William Raymann.
 * Class: CustomizeCobblerControl.
 * Purpose: To provide a UI for selecting the flavor of a Cobbler and specify
 *          whether the Cobbler should be served with ice cream.
 */
using System;
using System.Collections.Generic;
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

namespace ExamTwoQuestions.PointOfSale
{
    /// <summary>
    /// Interaction logic for CustomizeCobblerControl.xaml
    /// </summary>
    public partial class CustomizeCobblerControl : UserControl
    {
        /// <summary>
        /// Create a WPF control for customizing a Cobbler order.
        /// </summary>
        public CustomizeCobblerControl()
        {
            InitializeComponent();
        }
    }
}
