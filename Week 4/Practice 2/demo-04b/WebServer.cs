namespace demo_04b;

/// <summary>
/// Maintain a queue for all Web requests.  Process each one in the
/// order they were received.<br />
/// Requirements:<br />
/// 1. The AddRequest function shall enqueue a new web request into the queue.<br />
/// 2. The ProcessRequest function shall dequeue the next web request and process it.<br />
/// 3. If the queue is empty, then an error message will be displayed.<br />
/// </summary>
public class WebServer {
    /// <summary> Using a List as a queue </summary>
    private readonly List<WebRequest> _queue = new List<WebRequest>();

    /// <summary>
    /// Holds the data for each web request. This is called an inner class
    /// </summary>
    private class WebRequest {
        private readonly string _ipAddress;
        private readonly string _request;

        public WebRequest(string ipAddress, string request) {
            _ipAddress = ipAddress;
            _request = request;
        }

        public void Process() {
            Console.WriteLine($"Processing {_request} from {_ipAddress}");
        }
    }

    /// <summary>
    /// AddRequest will take those and create a new request and add it to the queue.
    /// </summary>
    /// <param name="ipAddress">the address the request is from</param>
    /// <param name="requestNumber">a request number</param>
    public void AddRequest(string ipAddress, string requestNumber) {
        WebRequest request = new WebRequest(ipAddress, requestNumber);
        _queue.Add(request);
    }

    /// <summary>
    /// ProcessRequest will then change the Queue to an array to check
    /// the length and then see if there is anything in the array and
    /// then will dequeue what is in it.
    /// </summary>
    public void ProcessRequest() {
        if (_queue.Count > 0) {
            WebRequest request = _queue[0];
            request.Process();
        }
        else {
            Console.WriteLine("The web queue is empty.");
        }
    }
}