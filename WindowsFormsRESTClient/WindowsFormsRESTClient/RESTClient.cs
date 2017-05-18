using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsRESTClient
{
    public partial class RestClient : Form
    {

        public RestClient()
        {
            InitializeComponent();
        }

        private void RestClient_Load( object sender, EventArgs e )
        {
            RestType.AddItemsToComboBox( cbRestType );
            ContentType.AddItemsToComboBox( cbContentType );
            cbRestType.SelectedIndex = RestType.GET;
            cbContentType.SelectedIndex = ContentType.APPLICATION_XML;
            tbURL.Text = "https://jsonplaceholder.typicode.com/posts";
            tbResponseCodeOutput.Text = "0";
            tbReceivedMessage.Text = "Body";
            tbHeaders.Text = "Headers";
        }

        private void CbRestType_SelectedIndexChanged( object sender, EventArgs e )
        {
            switch ( cbRestType.SelectedIndex ) {
            case RestType.GET:
            case RestType.DELETE:
                cbContentType.Enabled = false;
                tbReceivedMessage.ReadOnly = true;
                break;
            case RestType.POST:
            case RestType.PUT:
            case RestType.PATCH:
                cbContentType.Enabled = true;
                tbReceivedMessage.ReadOnly = false;
                break;
            }
        }

        private void BtnPerform_Click( object sender, EventArgs e )
        {
            switch ( cbRestType.SelectedIndex ) {
            case RestType.GET:
                UseHttpRestSenderSkeleton( RestType.GET );
                break;
            case RestType.POST:
                UseHttpRestSenderSkeleton( RestType.POST );
                break;
            case RestType.PUT:
                UseHttpRestSenderSkeleton( RestType.PUT );
                break;
            case RestType.DELETE:
                UseHttpRestSenderSkeleton( RestType.DELETE );
                break;
            case RestType.PATCH:
                UseHttpRestSenderSkeleton( RestType.PATCH );
                break;
            }
        }

        private void UseHttpRestSenderSkeleton( int restType )
        {
            try {
                UpdateTextBoxAndRefresh( tbResponseCodeOutput, "Performing..." );

                switch ( restType ) {
                case RestType.GET:
                    SendHttpGet( tbURL );
                    break;
                case RestType.POST:
                    SendHttpPost( tbURL, tbReceivedMessage );
                    break;
                case RestType.PUT:
                    SendHttpPut( tbURL, tbReceivedMessage );
                    break;
                case RestType.DELETE:
                    SendHttpDelete( tbURL );
                    break;
                case RestType.PATCH:
                    SendHttpPatch( tbURL, tbReceivedMessage );
                    break;
                }
            }
            catch ( WebException x ) {
                var response = x.Response as HttpWebResponse;

                if ( response != null ) {
                    string responseCodeInfo = (int) response.StatusCode + " " + response.StatusCode.ToString();
                    UpdateTextBoxAndRefresh( tbResponseCodeOutput, responseCodeInfo );
                    UpdateTextBoxAndRefresh( tbReceivedMessage, "" );
                    UpdateTextBoxAndRefresh( tbHeaders, "" );
                }
                else {
                    UpdateUIToInformAboutException();
                }

                MessageBox.Show( x.Message, x.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
            }
            catch ( NotSupportedException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( ObjectDisposedException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( IOException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( OutOfMemoryException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( ArgumentNullException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( ArgumentOutOfRangeException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( EncoderFallbackException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( ArgumentException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( System.Security.SecurityException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( UriFormatException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( InvalidCastException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( ProtocolViolationException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( InvalidOperationException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( NotImplementedException x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
            catch ( Exception x ) {
                UpdateUIAndShowMessageBoxWithCatchedException( x );
            }
        }

        private void UpdateTextBoxAndRefresh( TextBox textBox, string text )
        {
            textBox.Text = text;
            textBox.Refresh();
        }

        private void UpdateUIToInformAboutException()
        {
            UpdateTextBoxAndRefresh( tbResponseCodeOutput, "Failed" );
            UpdateTextBoxAndRefresh( tbReceivedMessage, "" );
            UpdateTextBoxAndRefresh( tbHeaders, "" );
        }

        private void UpdateUIAndShowMessageBoxWithCatchedException( Exception x )
        {
            UpdateUIToInformAboutException();
            MessageBox.Show( x.Message, x.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
        }

        private void SendHttpGet( TextBox url )
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( url.Text );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpDelete( TextBox url )
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( url.Text );
            request.Method = "DELETE";
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpPost( TextBox url, TextBox message )
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create( url.Text );
            SetSelectedContentType( request );
            request.ContentLength = message.Text.Length;
            request.Method = "POST";
            SetAcceptHeaderAsSelectedContentType( request );
            SendHttpRequest( request, message );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpPut( TextBox url, TextBox message )
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( url.Text );
            SetSelectedContentType( request );
            request.ContentLength = message.Text.Length;
            request.Method = "PUT";
            SetAcceptHeaderAsSelectedContentType( request );
            SendHttpRequest( request, message );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpPatch( TextBox url, TextBox message )
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( url.Text );
            SetSelectedContentType( request );
            request.ContentLength = message.Text.Length;
            request.Method = "PATCH";
            SetAcceptHeaderAsSelectedContentType( request );
            SendHttpRequest( request, message );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SetSelectedContentType( WebRequest request )
        {
            switch ( cbContentType.SelectedIndex ) {
            case ContentType.APPLICATION_JSON:
                request.ContentType = ContentType.APPLICATION_JSON_STRING;
                break;
            case ContentType.APPLICATION_XML:
                request.ContentType = ContentType.APPLICATION_XML_STRING;
                break;
            case ContentType.APPLICATION_OCTET_STREAM:
                request.ContentType = ContentType.APPLICATION_OCTET_STREAM_STRING;
                break;
            case ContentType.TEXT_CSS:
                request.ContentType = ContentType.TEXT_CSS_STRING;
                break;
            case ContentType.TEXT_CSV:
                request.ContentType = ContentType.TEXT_CSV_STRING;
                break;
            case ContentType.APPLICATION_MS_WORD:
                request.ContentType = ContentType.APPLICATION_MS_WORD_STRING;
                break;
            case ContentType.TEXT_HTML:
                request.ContentType = ContentType.TEXT_HTML_STRING;
                break;
            case ContentType.APPLICATION_XHTML_XML:
                request.ContentType = ContentType.APPLICATION_XHTML_XML_STRING;
                break;
            case ContentType.IMAGE_X_ICON:
                request.ContentType = ContentType.IMAGE_X_ICON_STRING;
                break;
            case ContentType.APPLICATION_JAVA_ARCHIVE:
                request.ContentType = ContentType.APPLICATION_JAVA_ARCHIVE_STRING;
                break;
            case ContentType.IMAGE_JPEG:
                request.ContentType = ContentType.IMAGE_JPEG_STRING;
                break;
            case ContentType.APPLICATION_JAVA_SCRIPT:
                request.ContentType = ContentType.APPLICATION_JAVA_SCRIPT_STRING;
                break;
            case ContentType.APPLICATION_PDF:
                request.ContentType = ContentType.APPLICATION_PDF_STRING;
                break;
            case ContentType.FONT_TTF:
                request.ContentType = ContentType.FONT_TTF_STRING;
                break;
            case ContentType.VIDEO_WEBM:
                request.ContentType = ContentType.VIDEO_WEBM_STRING;
                break;
            case ContentType.AUDIO_WEBM:
                request.ContentType = ContentType.AUDIO_WEBM_STRING;
                break;
            case ContentType.IMAGE_WEBP:
                request.ContentType = ContentType.IMAGE_WEBP_STRING;
                break;
            case ContentType.APPLICATION_ZIP:
                request.ContentType = ContentType.APPLICATION_ZIP_STRING;
                break;
            case ContentType.APPLICATION_X_TAR:
                request.ContentType = ContentType.APPLICATION_X_TAR_STRING;
                break;
            case ContentType.APPLICATION_X_RAR_COMPRESSED:
                request.ContentType = ContentType.APPLICATION_X_RAR_COMPRESSED_STRING;
                break;
            case ContentType.APPLICATION_X_7Z_COMPRESSED:
                request.ContentType = ContentType.APPLICATION_X_7Z_COMPRESSED_STRING;
                break;
            case ContentType.IMAGE_SVG_XML:
                request.ContentType = ContentType.IMAGE_SVG_XML_STRING;
                break;
            }
        }

        private void GetHttpResponseAndUpdateUI( WebRequest request )
        {
            using ( HttpWebResponse response = (HttpWebResponse) request.GetResponse() ) {
                using ( var reader = new StreamReader( response.GetResponseStream() ) ) {
                    var result = reader.ReadToEnd();
                    string responseCodeInfo = (int) response.StatusCode + " " + response.StatusCode.ToString();
                    UpdateTextBoxAndRefresh( tbResponseCodeOutput, responseCodeInfo );
                    UpdateTextBoxAndRefresh( tbReceivedMessage, Convert.ToString( result ) );
                    UpdateTextBoxAndRefresh( tbHeaders, response.Headers.ToString() );
                }
            }
        }

        private void SendHttpRequest( WebRequest request, TextBox textToSend )
        {
            using ( var requestStream = request.GetRequestStream() ) {
                var dataToSend = Encoding.UTF8.GetBytes( textToSend.Text );
                request.GetRequestStream().Write( dataToSend, 0, dataToSend.Length );
            }
        }

        private void SetAcceptHeaderAsSelectedContentType( HttpWebRequest httpRequest )
        {
            switch ( cbContentType.SelectedIndex ) {
            case ContentType.APPLICATION_JSON:
                httpRequest.Accept = ContentType.APPLICATION_JSON_STRING;
                break;
            case ContentType.APPLICATION_XML:
                httpRequest.Accept = ContentType.APPLICATION_XML_STRING;
                break;
            case ContentType.APPLICATION_OCTET_STREAM:
                httpRequest.Accept = ContentType.APPLICATION_OCTET_STREAM_STRING;
                break;
            case ContentType.TEXT_CSS:
                httpRequest.Accept = ContentType.TEXT_CSS_STRING;
                break;
            case ContentType.TEXT_CSV:
                httpRequest.Accept = ContentType.TEXT_CSV_STRING;
                break;
            case ContentType.APPLICATION_MS_WORD:
                httpRequest.Accept = ContentType.APPLICATION_MS_WORD_STRING;
                break;
            case ContentType.TEXT_HTML:
                httpRequest.Accept = ContentType.TEXT_HTML_STRING;
                break;
            case ContentType.APPLICATION_XHTML_XML:
                httpRequest.Accept = ContentType.APPLICATION_XHTML_XML_STRING;
                break;
            case ContentType.IMAGE_X_ICON:
                httpRequest.Accept = ContentType.IMAGE_X_ICON_STRING;
                break;
            case ContentType.APPLICATION_JAVA_ARCHIVE:
                httpRequest.Accept = ContentType.APPLICATION_JAVA_ARCHIVE_STRING;
                break;
            case ContentType.IMAGE_JPEG:
                httpRequest.Accept = ContentType.IMAGE_JPEG_STRING;
                break;
            case ContentType.APPLICATION_JAVA_SCRIPT:
                httpRequest.Accept = ContentType.APPLICATION_JAVA_SCRIPT_STRING;
                break;
            case ContentType.APPLICATION_PDF:
                httpRequest.Accept = ContentType.APPLICATION_PDF_STRING;
                break;
            case ContentType.FONT_TTF:
                httpRequest.Accept = ContentType.FONT_TTF_STRING;
                break;
            case ContentType.VIDEO_WEBM:
                httpRequest.Accept = ContentType.VIDEO_WEBM_STRING;
                break;
            case ContentType.AUDIO_WEBM:
                httpRequest.Accept = ContentType.AUDIO_WEBM_STRING;
                break;
            case ContentType.IMAGE_WEBP:
                httpRequest.Accept = ContentType.IMAGE_WEBP_STRING;
                break;
            case ContentType.APPLICATION_ZIP:
                httpRequest.Accept = ContentType.APPLICATION_ZIP_STRING;
                break;
            case ContentType.APPLICATION_X_TAR:
                httpRequest.Accept = ContentType.APPLICATION_X_TAR_STRING;
                break;
            case ContentType.APPLICATION_X_RAR_COMPRESSED:
                httpRequest.Accept = ContentType.APPLICATION_X_RAR_COMPRESSED_STRING;
                break;
            case ContentType.APPLICATION_X_7Z_COMPRESSED:
                httpRequest.Accept = ContentType.APPLICATION_X_7Z_COMPRESSED_STRING;
                break;
            case ContentType.IMAGE_SVG_XML:
                httpRequest.Accept = ContentType.IMAGE_SVG_XML_STRING;
                break;
            }
        }

    }
}
