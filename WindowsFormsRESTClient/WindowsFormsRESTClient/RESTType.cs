using System.Windows.Forms;

namespace WindowsFormsRESTClient
{
    internal static class RESTType
    {

        public const int GET = 0;
        public const int POST = 1;
        public const int PUT = 2;
        public const int DELETE = 3;
        public const int PATCH = 4;

        public static void AddItemsToComboBox( ComboBox comboBox )
        {
            comboBox.Items.Clear();
            comboBox.Items.Add( "GET" );
            comboBox.Items.Add( "POST" );
            comboBox.Items.Add( "PUT" );
            comboBox.Items.Add( "DELETE" );
            comboBox.Items.Add( "PATCH" );
        }

    }
}
