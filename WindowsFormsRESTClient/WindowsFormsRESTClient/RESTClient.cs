using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsRESTClient
{
    public partial class RESTClient : Form
    {

        public RESTClient()
        {
            InitializeComponent();
        }

        private void RESTClient_Load( object sender, EventArgs e )
        {
            RESTType.AddItemsToComboBox( cbRESTType );
            ContentType.AddItemsToComboBox( cbContentType );
            cbRESTType.SelectedIndex = RESTType.GET;
            cbContentType.SelectedIndex = ContentType.APPLICATION_JSON;
            tbURL.Text = "https://jsonplaceholder.typicode.com/posts";
        }

        private void CbRESTType_SelectedIndexChanged( object sender, EventArgs e )
        {
            switch ( cbRESTType.SelectedIndex ) {
            case RESTType.GET:
                cbContentType.Enabled = false;
                tbReceivedMessage.ReadOnly = true;
                break;
            case RESTType.POST:
                cbContentType.Enabled = true;
                tbReceivedMessage.ReadOnly = false;
                break;
            case RESTType.PUT:
                cbContentType.Enabled = true;
                tbReceivedMessage.ReadOnly = false;
                break;
            case RESTType.DELETE:
                cbContentType.Enabled = false;
                tbReceivedMessage.ReadOnly = true;
                break;
            case RESTType.PATCH:
                cbContentType.Enabled = true;
                tbReceivedMessage.ReadOnly = false;
                break;
            }
        }

        private void BtnPerform_Click( object sender, EventArgs e )
        {
            switch ( cbRESTType.SelectedIndex ) {
            case RESTType.GET:
                UseHttpRESTSenderSkeleton( RESTType.GET );
                break;
            case RESTType.POST:
                UseHttpRESTSenderSkeleton( RESTType.POST );
                break;
            case RESTType.PUT:
                UseHttpRESTSenderSkeleton( RESTType.PUT );
                break;
            case RESTType.DELETE:
                UseHttpRESTSenderSkeleton( RESTType.DELETE );
                break;
            case RESTType.PATCH:
                UseHttpRESTSenderSkeleton( RESTType.PATCH );
                break;
            }
        }

        private void UseHttpRESTSenderSkeleton( int restType )
        {
            try {
                UpdateTextBoxAndRefresh( tbResponseCodeOutput, "Performing..." );

                switch ( restType ) {
                case RESTType.GET:
                    SendHttpGET( tbURL );
                    break;
                case RESTType.POST:
                    SendHttpPOST( tbURL, tbReceivedMessage );
                    break;
                case RESTType.PUT:
                    SendHttpPUT( tbURL, tbReceivedMessage );
                    break;
                case RESTType.DELETE:
                    SendHttpDELETE( tbURL );
                    break;
                case RESTType.PATCH:
                    SendHttpPATCH( tbURL, tbReceivedMessage );
                    break;
                }
            }
            catch ( WebException x ) {
                var response = x.Response as HttpWebResponse;

                if ( response != null ) {
                    string responseCodeInfo = (int) response.StatusCode + " " + response.StatusCode.ToString();
                    UpdateTextBoxAndRefresh( tbResponseCodeOutput, responseCodeInfo );
                    UpdateTextBoxAndRefresh( tbReceivedMessage, "" );
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
        }

        private void UpdateUIAndShowMessageBoxWithCatchedException( Exception x )
        {
            UpdateUIToInformAboutException();
            MessageBox.Show( x.Message, x.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
        }

        private void SendHttpGET( TextBox url )
        {
            WebRequest request = WebRequest.Create( url.Text );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpDELETE( TextBox url )
        {
            WebRequest request = WebRequest.Create( url.Text );
            request.Method = "DELETE";
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpPOST( TextBox url, TextBox message )
        {
            WebRequest request = WebRequest.Create( url.Text );
            SetSelectedContentType( request );
            request.ContentLength = message.Text.Length;
            request.Method = "POST";
            SendHttpRequest( request, message );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpPUT( TextBox url, TextBox message )
        {
            WebRequest request = WebRequest.Create( url.Text );
            SetSelectedContentType( request );
            request.ContentLength = message.Text.Length;
            request.Method = "PUT";
            SendHttpRequest( request, message );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SendHttpPATCH( TextBox url, TextBox message )
        {
            WebRequest request = WebRequest.Create( url.Text );
            SetSelectedContentType( request );
            request.ContentLength = message.Text.Length;
            request.Method = "PATCH";
            SendHttpRequest( request, message );
            GetHttpResponseAndUpdateUI( request );
        }

        private void SetSelectedContentType( WebRequest request )
        {
            switch ( cbContentType.SelectedIndex ) {
            case ContentType.APPLICATION_XML:
                request.ContentType = "application/xml; charset=utf-8";
                break;
            case ContentType.APPLICATION_OCTET_STREAM:
                request.ContentType = "application/octet-stream";
                break;
            case ContentType.TEXT_CSS:
                request.ContentType = "text/css";
                break;
            case ContentType.TEXT_CSV:
                request.ContentType = "text/csv";
                break;
            case ContentType.APPLICATION_MS_WORD:
                request.ContentType = "application/msword";
                break;
            case ContentType.TEXT_HTML:
                request.ContentType = "text/html";
                break;
            case ContentType.APPLICATION_XHTML_XML:
                request.ContentType = "application/xhtml+xml";
                break;
            case ContentType.IMAGE_X_ICON:
                request.ContentType = "image/x-icon";
                break;
            case ContentType.APPLICATION_JAVA_ARCHIVE:
                request.ContentType = "application/java-archive";
                break;
            case ContentType.IMAGE_JPEG:
                request.ContentType = "image/jpeg";
                break;
            case ContentType.APPLICATION_JAVA_SCRIPT:
                request.ContentType = "application/javascript";
                break;
            case ContentType.APPLICATION_PDF:
                request.ContentType = "application/pdf";
                break;
            case ContentType.FONT_TTF:
                request.ContentType = "font/ttf";
                break;
            case ContentType.VIDEO_WEBM:
                request.ContentType = "video/webm";
                break;
            case ContentType.AUDIO_WEBM:
                request.ContentType = "audio/webm";
                break;
            case ContentType.IMAGE_WEBP:
                request.ContentType = "image/webp";
                break;
            case ContentType.APPLICATION_ZIP:
                request.ContentType = "application/zip";
                break;
            case ContentType.APPLICATION_X_TAR:
                request.ContentType = "application/x-tar";
                break;
            case ContentType.APPLICATION_X_RAR_COMPRESSED:
                request.ContentType = "application/x-rar-compressed";
                break;
            case ContentType.APPLICATION_X_7Z_COMPRESSED:
                request.ContentType = "application/x-7z-compressed";
                break;
            case ContentType.IMAGE_SVG_XML:
                request.ContentType = "image/svg+xml";
                break;
            case ContentType.APPLICATION_JSON:
            default:
                request.ContentType = "application/json; charset=utf-8";
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

    }
}
