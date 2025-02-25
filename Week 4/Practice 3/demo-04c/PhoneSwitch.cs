namespace demo_04c;

/// <summary>
/// Maintain a queue for all Phone calls.  Phone calls are processed in a first
/// come first serve order unless the queue is full or a emergency 911 call has
/// been made.<br />
/// Requirements:<br />
/// 1) The RequestCall function shall enqueue the phone call into the queue.<br />
/// 2) If the queue is full, then a 'Line Busy' error message shall be given.<br />
/// 3) If the number is 911, the call shall be put in the front of the line.<br />
/// 4) The ProcessNextCall function shall connect the next phone call from the queue.<br />
/// 5) If the queue is empty, then an error message shall be given.<br />
/// </summary>
public class PhoneSwitch {
    /// <summary>PhoneCall is an inner class that takes a number as a parameter.</summary>
    private class PhoneCall {
        private readonly string _number;

        public PhoneCall(string number) {
            _number = number;
        }

        /// <summary>Connect the call</summary>
        public void ConnectCall() {
            Console.WriteLine($"Call connected for {_number}");
        }
    }

    // Uses a List as a queue 
    private readonly List<PhoneCall> _phoneQueue = new List<PhoneCall>();
    private readonly int _maxQueueSize;

    /// <summary>
    /// Phone Switch with a maximum number of calls in the queue
    /// </summary>
    /// <param name="maxQueueSize">max number of calls allowed</param>
    public PhoneSwitch(int maxQueueSize) {
        _maxQueueSize = maxQueueSize;
    }

    public void RequestCall(string number) {
        PhoneCall request = new PhoneCall(number);
        if (_phoneQueue.Count <= _maxQueueSize) {
            if (number == "911") {
                _phoneQueue.Insert(1, request);
            }
            else {
                _phoneQueue.Add(request);
            }
        }
        else {
            Console.WriteLine($"Line is busy. Unable to make call to {number}");
        }
    }

    public void ProcessNextCall() {
        if (_phoneQueue.Count > 0) {
            PhoneCall call = _phoneQueue[0];
            _phoneQueue.RemoveAt(0);
            call.ConnectCall();
        }
        else {
            Console.WriteLine("The phone queue is empty.");
        }
    }
}