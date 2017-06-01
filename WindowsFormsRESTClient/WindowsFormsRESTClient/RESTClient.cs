using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsRESTClient
{
    public partial class RestClient : Form
    {

        private readonly RestHttpHelper restHelper = new RestHttpHelper();

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
            tbURL.Text = "https://jsonplaceholder.typicode.com/users";
            tbResponseCodeOutput.Text = "0";
            tbMessage.Text = "Body";
            tbHeaders.Text = "Headers";
        }

        private void CbRestType_SelectedIndexChanged( object sender, EventArgs e )
        {
            switch ( cbRestType.SelectedIndex ) {
            case RestType.GET:
            case RestType.DELETE:
                cbContentType.Enabled = false;
                tbMessage.ReadOnly = true;
                break;
            case RestType.POST:
            case RestType.PUT:
            case RestType.PATCH:
                cbContentType.Enabled = true;
                tbMessage.ReadOnly = false;
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
                    SendHttpPost( tbURL, tbMessage );
                    break;
                case RestType.PUT:
                    SendHttpPut( tbURL, tbMessage );
                    break;
                case RestType.DELETE:
                    SendHttpDelete( tbURL );
                    break;
                case RestType.PATCH:
                    SendHttpPatch( tbURL, tbMessage );
                    break;
                }
            }
            catch ( WebException x ) {
                var response = x.Response as HttpWebResponse;

                if ( response != null ) {
                    string responseCodeInfo = (int) response.StatusCode + " " + response.StatusCode.ToString();
                    UpdateTextBoxAndRefresh( tbResponseCodeOutput, responseCodeInfo );
                    UpdateTextBoxAndRefresh( tbMessage, "" );
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
            const string FAILURE_MESSAGE = "Failed. Exception was thrown.";
            UpdateTextBoxAndRefresh( tbResponseCodeOutput, FAILURE_MESSAGE );
            UpdateTextBoxAndRefresh( tbMessage, FAILURE_MESSAGE );
            UpdateTextBoxAndRefresh( tbHeaders, FAILURE_MESSAGE );
        }

        private void UpdateUIAndShowMessageBoxWithCatchedException( Exception x )
        {
            UpdateUIToInformAboutException();
            MessageBox.Show( x.Message, x.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Asterisk );
        }

        private void SendHttpGet( TextBox url )
        {
            HttpResponseMessage response = restHelper.HttpGet( url.Text );
            UpdateUIToDisplayResponse( response );
        }

        private void SendHttpDelete( TextBox url )
        {
            HttpResponseMessage response = restHelper.HttpDelete( url.Text );
            UpdateUIToDisplayResponse( response );
        }

        private void SendHttpPost( TextBox url, TextBox message )
        {
            HttpResponseMessage response = restHelper.HttpPost( url.Text, message.Text, GetSelectedContentType(), GetAcceptHeaderAsSelectedContentType() );
            UpdateUIToDisplayResponse( response );
        }

        private void SendHttpPut( TextBox url, TextBox message )
        {
            HttpResponseMessage response = restHelper.HttpPut( url.Text, message.Text, GetSelectedContentType(), GetAcceptHeaderAsSelectedContentType() );
            UpdateUIToDisplayResponse( response );
        }

        private void SendHttpPatch( TextBox url, TextBox message )
        {
            HttpResponseMessage response = restHelper.HttpPatch( url.Text, message.Text, GetSelectedContentType(), GetAcceptHeaderAsSelectedContentType() );
            UpdateUIToDisplayResponse( response );
        }

        private string GetSelectedContentType()
        {
            switch ( cbContentType.SelectedIndex ) {
            case ContentType.APPLICATION_JSON:
                return ContentType.APPLICATION_JSON_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_XML:
                return ContentType.APPLICATION_XML_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_OCTET_STREAM:
                return ContentType.APPLICATION_OCTET_STREAM_STRING + ";charset=utf-8";
            case ContentType.TEXT_CSS:
                return ContentType.TEXT_CSS_STRING + ";charset=utf-8";
            case ContentType.TEXT_CSV:
                return ContentType.TEXT_CSV_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_MS_WORD:
                return ContentType.APPLICATION_MS_WORD_STRING + ";charset=utf-8";
            case ContentType.TEXT_HTML:
                return ContentType.TEXT_HTML_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_XHTML_XML:
                return ContentType.APPLICATION_XHTML_XML_STRING + ";charset=utf-8";
            case ContentType.IMAGE_X_ICON:
                return ContentType.IMAGE_X_ICON_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_JAVA_ARCHIVE:
                return ContentType.APPLICATION_JAVA_ARCHIVE_STRING + ";charset=utf-8";
            case ContentType.IMAGE_JPEG:
                return ContentType.IMAGE_JPEG_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_JAVA_SCRIPT:
                return ContentType.APPLICATION_JAVA_SCRIPT_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_PDF:
                return ContentType.APPLICATION_PDF_STRING + ";charset=utf-8";
            case ContentType.FONT_TTF:
                return ContentType.FONT_TTF_STRING + ";charset=utf-8";
            case ContentType.VIDEO_WEBM:
                return ContentType.VIDEO_WEBM_STRING + ";charset=utf-8";
            case ContentType.AUDIO_WEBM:
                return ContentType.AUDIO_WEBM_STRING + ";charset=utf-8";
            case ContentType.IMAGE_WEBP:
                return ContentType.IMAGE_WEBP_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_ZIP:
                return ContentType.APPLICATION_ZIP_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_X_TAR:
                return ContentType.APPLICATION_X_TAR_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_X_RAR_COMPRESSED:
                return ContentType.APPLICATION_X_RAR_COMPRESSED_STRING + ";charset=utf-8";
            case ContentType.APPLICATION_X_7Z_COMPRESSED:
                return ContentType.APPLICATION_X_7Z_COMPRESSED_STRING + ";charset=utf-8";
            case ContentType.IMAGE_SVG_XML:
                return ContentType.IMAGE_SVG_XML_STRING + ";charset=utf-8";
            }

            return null;
        }

        private void UpdateUIToDisplayResponse( HttpResponseMessage response )
        {
            UpdateTextBoxAndRefresh( tbResponseCodeOutput, response.StatusCode + " " + response.StatusMessage );
            UpdateTextBoxAndRefresh( tbMessage, response.ResultMessage );
            UpdateTextBoxAndRefresh( tbHeaders, response.HeadersMessage );
        }

        private string GetAcceptHeaderAsSelectedContentType()
        {
            switch ( cbContentType.SelectedIndex ) {
            case ContentType.APPLICATION_JSON:
                return ContentType.APPLICATION_JSON_STRING;
            case ContentType.APPLICATION_XML:
                return ContentType.APPLICATION_XML_STRING;
            case ContentType.APPLICATION_OCTET_STREAM:
                return ContentType.APPLICATION_OCTET_STREAM_STRING;
            case ContentType.TEXT_CSS:
                return ContentType.TEXT_CSS_STRING;
            case ContentType.TEXT_CSV:
                return ContentType.TEXT_CSV_STRING;
            case ContentType.APPLICATION_MS_WORD:
                return ContentType.APPLICATION_MS_WORD_STRING;
            case ContentType.TEXT_HTML:
                return ContentType.TEXT_HTML_STRING;
            case ContentType.APPLICATION_XHTML_XML:
                return ContentType.APPLICATION_XHTML_XML_STRING;
            case ContentType.IMAGE_X_ICON:
                return ContentType.IMAGE_X_ICON_STRING;
            case ContentType.APPLICATION_JAVA_ARCHIVE:
                return ContentType.APPLICATION_JAVA_ARCHIVE_STRING;
            case ContentType.IMAGE_JPEG:
                return ContentType.IMAGE_JPEG_STRING;
            case ContentType.APPLICATION_JAVA_SCRIPT:
                return ContentType.APPLICATION_JAVA_SCRIPT_STRING;
            case ContentType.APPLICATION_PDF:
                return ContentType.APPLICATION_PDF_STRING;
            case ContentType.FONT_TTF:
                return ContentType.FONT_TTF_STRING;
            case ContentType.VIDEO_WEBM:
                return ContentType.VIDEO_WEBM_STRING;
            case ContentType.AUDIO_WEBM:
                return ContentType.AUDIO_WEBM_STRING;
            case ContentType.IMAGE_WEBP:
                return ContentType.IMAGE_WEBP_STRING;
            case ContentType.APPLICATION_ZIP:
                return ContentType.APPLICATION_ZIP_STRING;
            case ContentType.APPLICATION_X_TAR:
                return ContentType.APPLICATION_X_TAR_STRING;
            case ContentType.APPLICATION_X_RAR_COMPRESSED:
                return ContentType.APPLICATION_X_RAR_COMPRESSED_STRING;
            case ContentType.APPLICATION_X_7Z_COMPRESSED:
                return ContentType.APPLICATION_X_7Z_COMPRESSED_STRING;
            case ContentType.IMAGE_SVG_XML:
                return ContentType.IMAGE_SVG_XML_STRING;
            }

            return null;
        }

    }
}
