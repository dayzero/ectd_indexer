using System;
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

namespace eCTD_Diagnostic
{
    public class eCTD_DiagnosticControl : Control
    {
        static eCTD_DiagnosticControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(eCTD_DiagnosticControl), new FrameworkPropertyMetadata(typeof(eCTD_DiagnosticControl)));
        }
    }
}
