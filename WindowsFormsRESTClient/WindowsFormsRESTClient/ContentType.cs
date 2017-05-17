using System.Windows.Forms;

namespace WindowsFormsRESTClient
{
    internal static class ContentType
    {

        public const int APPLICATION_JSON = 0;
        public const int APPLICATION_XML = 1;
        public const int APPLICATION_OCTET_STREAM = 2;
        public const int TEXT_CSS = 3;
        public const int TEXT_CSV = 4;
        public const int APPLICATION_MS_WORD = 5;
        public const int TEXT_HTML = 6;
        public const int APPLICATION_XHTML_XML = 7;
        public const int IMAGE_X_ICON = 8;
        public const int APPLICATION_JAVA_ARCHIVE = 9;
        public const int IMAGE_JPEG = 10;
        public const int APPLICATION_JAVA_SCRIPT = 11;
        public const int APPLICATION_PDF = 12;
        public const int FONT_TTF = 13;
        public const int VIDEO_WEBM = 14;
        public const int AUDIO_WEBM = 15;
        public const int IMAGE_WEBP = 16;
        public const int APPLICATION_ZIP = 17;
        public const int APPLICATION_X_TAR = 18;
        public const int APPLICATION_X_RAR_COMPRESSED = 19;
        public const int APPLICATION_X_7Z_COMPRESSED = 20;
        public const int IMAGE_SVG_XML = 21;

        public static void AddItemsToComboBox( ComboBox comboBox )
        {
            comboBox.Items.Clear();
            comboBox.Items.Add( "application/json (.json)" );
            comboBox.Items.Add( "application/xml (.xml)" );
            comboBox.Items.Add( "application/octet-stream (.bin, .arc)" );
            comboBox.Items.Add( "text/css (.css)" );
            comboBox.Items.Add( "text/csv (.csv)" );
            comboBox.Items.Add( "application/msword (.doc)" );
            comboBox.Items.Add( "text/html (.html, .htm)" );
            comboBox.Items.Add( "application/xhtml+xml (.xhtml)" );
            comboBox.Items.Add( "image/x-icon (.ico)" );
            comboBox.Items.Add( "application/java-archive (.jar)" );
            comboBox.Items.Add( "image/jpeg (.jpeg, .jpg)" );
            comboBox.Items.Add( "application/javascript (.js)" );
            comboBox.Items.Add( "application/pdf (.pdf)" );
            comboBox.Items.Add( "font/ttf (.ttf)" );
            comboBox.Items.Add( "video/webm (.webm)" );
            comboBox.Items.Add( "audio/webm (.weba)" );
            comboBox.Items.Add( "image/webp (.webp)" );
            comboBox.Items.Add( "application/zip (.zip)" );
            comboBox.Items.Add( "application/x-tar (.tar)" );
            comboBox.Items.Add( "application/x-rar-compressed (.rar)" );
            comboBox.Items.Add( "application/x-7z-compressed (.7z)" );
            comboBox.Items.Add( "image/svg+xml (.svg)" );
        }

    }
}
