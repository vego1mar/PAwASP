namespace WindowsFormsRESTClient
{

    public struct HttpResponseMessage
    {

        public int StatusCode { get; set; } 
        public string StatusMessage { get; set; } 
        public string ResultMessage { get; set; }
        public string HeadersMessage { get; set; } 

    }

}
