using System.IO;
using System.Net;
using System.Text;

namespace WindowsFormsRESTClient
{

    public class RestHttpHelper : IRestHttpHelper
    {

        public virtual HttpResponseMessage HttpGet( string url )
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create( url );
            return GetHttpResponse( request );
        }

        public virtual HttpResponseMessage HttpDelete( string url )
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create( url );
            request.Method = "DELETE";
            return GetHttpResponse( request );
        }

        public virtual HttpResponseMessage HttpPost( string url, string content, string contentType, string acceptHeader )
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create( url );
            request.Method = "POST";
            SetHeadersAndSendRequest( ref request, content, contentType, acceptHeader );
            return GetHttpResponse( request );
        }

        public virtual HttpResponseMessage HttpPut( string url, string content, string contentType, string acceptHeader )
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create( url );
            request.Method = "PUT";
            SetHeadersAndSendRequest( ref request, content, contentType, acceptHeader );
            return GetHttpResponse( request );
        }

        public virtual HttpResponseMessage HttpPatch( string url, string content, string contentType, string acceptHeader )
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create( url );
            request.Method = "PATCH";
            SetHeadersAndSendRequest( ref request, content, contentType, acceptHeader );
            return GetHttpResponse( request );
        }

        private HttpResponseMessage GetHttpResponse( WebRequest request )
        {
            HttpResponseMessage output = new HttpResponseMessage();

            using ( HttpWebResponse response = (HttpWebResponse) request.GetResponse() ) {
                using ( var reader = new StreamReader( response.GetResponseStream() ) ) {
                    output.ResultMessage = reader.ReadToEnd();
                    output.StatusCode = (int) response.StatusCode;
                    output.StatusMessage = response.StatusCode.ToString();
                    output.HeadersMessage = response.Headers.ToString();
                }
            }

            return output;
        }

        private void SendHttpRequest( WebRequest request, string textToSend )
        {
            using ( var requestStream = request.GetRequestStream() ) {
                var dataToSend = Encoding.UTF8.GetBytes( textToSend );
                request.GetRequestStream().Write( dataToSend, 0, dataToSend.Length );
            }
        }

        private void SetHeadersAndSendRequest( ref HttpWebRequest request, string content, string contentType, string acceptHeader )
        {
            request.ContentType = contentType;
            request.ContentLength = content.Length;
            request.Accept = acceptHeader;
            SendHttpRequest( request, content );
        }

    }

}
