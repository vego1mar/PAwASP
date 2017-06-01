namespace WindowsFormsRESTClient
{

    public interface IRestHttpHelper
    {

        HttpResponseMessage HttpGet( string url );
        HttpResponseMessage HttpDelete( string url );
        HttpResponseMessage HttpPost( string url, string content, string contentType, string acceptHeader );
        HttpResponseMessage HttpPut( string url, string content, string contentType, string acceptHeader );
        HttpResponseMessage HttpPatch( string url, string content, string contentType, string acceptHeader );

    }

}
