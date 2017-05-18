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

        public const string APPLICATION_JSON_STRING = "application/json";
        public const string APPLICATION_XML_STRING = "application/xml";
        public const string APPLICATION_OCTET_STREAM_STRING = "application/octet-stream";
        public const string TEXT_CSS_STRING = "text/css";
        public const string TEXT_CSV_STRING = "text/csv";
        public const string APPLICATION_MS_WORD_STRING = "application/msword";
        public const string TEXT_HTML_STRING = "text/html";
        public const string APPLICATION_XHTML_XML_STRING = "application/xhtml+xml";
        public const string IMAGE_X_ICON_STRING = "image/x-icon";
        public const string APPLICATION_JAVA_ARCHIVE_STRING = "application/java-archive";
        public const string IMAGE_JPEG_STRING = "image/jpeg";
        public const string APPLICATION_JAVA_SCRIPT_STRING = "application/javascript";
        public const string APPLICATION_PDF_STRING = "application/pdf";
        public const string FONT_TTF_STRING = "font/ttf";
        public const string VIDEO_WEBM_STRING = "video/webm";
        public const string AUDIO_WEBM_STRING = "audio/webm";
        public const string IMAGE_WEBP_STRING = "image/webp";
        public const string APPLICATION_ZIP_STRING = "application/zip";
        public const string APPLICATION_X_TAR_STRING = "application/x-tar";
        public const string APPLICATION_X_RAR_COMPRESSED_STRING = "application/x-rar-compressed";
        public const string APPLICATION_X_7Z_COMPRESSED_STRING = "application/x-7z-compressed";
        public const string IMAGE_SVG_XML_STRING = "image/svg+xml";

        public static void AddItemsToComboBox( ComboBox comboBox )
        {
            comboBox.Items.Clear();
            comboBox.Items.Add( APPLICATION_JSON_STRING + " (.json)" );
            comboBox.Items.Add( APPLICATION_XML_STRING + " (.xml)" );
            comboBox.Items.Add( APPLICATION_OCTET_STREAM_STRING + " (.bin, .arc)" );
            comboBox.Items.Add( TEXT_CSS_STRING + " (.css)" );
            comboBox.Items.Add( TEXT_CSV_STRING + " (.csv)" );
            comboBox.Items.Add( APPLICATION_MS_WORD_STRING + " (.doc)" );
            comboBox.Items.Add( TEXT_HTML_STRING + " (.html, .htm)" );
            comboBox.Items.Add( APPLICATION_XHTML_XML_STRING + " (.xhtml)" );
            comboBox.Items.Add( IMAGE_X_ICON_STRING + " (.ico)" );
            comboBox.Items.Add( APPLICATION_JAVA_ARCHIVE_STRING + " (.jar)" );
            comboBox.Items.Add( IMAGE_JPEG_STRING + " (.jpeg, .jpg)" );
            comboBox.Items.Add( APPLICATION_JAVA_SCRIPT_STRING + " (.js)" );
            comboBox.Items.Add( APPLICATION_PDF_STRING + " (.pdf)" );
            comboBox.Items.Add( FONT_TTF_STRING + " (.ttf)" );
            comboBox.Items.Add( VIDEO_WEBM_STRING + " (.webm)" );
            comboBox.Items.Add( AUDIO_WEBM_STRING + " (.weba)" );
            comboBox.Items.Add( IMAGE_WEBP_STRING + " (.webp)" );
            comboBox.Items.Add( APPLICATION_ZIP_STRING + " (.zip)" );
            comboBox.Items.Add( APPLICATION_X_TAR_STRING + " (.tar)" );
            comboBox.Items.Add( APPLICATION_X_RAR_COMPRESSED_STRING + " (.rar)" );
            comboBox.Items.Add( APPLICATION_X_7Z_COMPRESSED_STRING + " (.7z)" );
            comboBox.Items.Add( IMAGE_SVG_XML_STRING + " (.svg)" );
        }

    }
}
