using demo_04b;

// Test Cases

// Test 1
// Scenario: Can I add one web request and then process the web request
// Expected Result: The web request that was added should be processed
Console.WriteLine("Test 1");
var server = new WebServer();
server.AddRequest("10.2.53.123", "https://byui.edu");
server.ProcessRequest();
// Defect(s) Found:

Console.WriteLine("=================");

// Test 2
// Scenario: Can I add three web requests and then process them in the proper order
// Expected Result: The three web requests should be processed in order from first to last
Console.WriteLine("Test 2");
server = new WebServer();
server.AddRequest("10.2.53.123", "https://byui.edu");
server.AddRequest("29.25.122.33", "https://churchofjesuschrist.org");
server.AddRequest("17.3.32.110", "https://weather.gov");
server.ProcessRequest();
server.ProcessRequest();
server.ProcessRequest();
// Defect(s) Found:

Console.WriteLine("=================");

// Test 3
// Scenario: Can I process a web request if there are no web requests
// Expected Result: This should display some error message
Console.WriteLine("Test 3");
server = new WebServer();
server.ProcessRequest();
// Defect(s) Found: