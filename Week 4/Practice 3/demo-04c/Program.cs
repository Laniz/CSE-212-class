using demo_04c;

//CSE 212 Lesson 4C 
// A Phone Switch that manages phone calls.  After the class, a set of tests 
// is written based on the Requirements shown in the PhoneSwitch class.  
// You will need to write at least one additional test case and then run the tests 
// to find the 2 errors in the code.

// Test Cases

// Test 1
// Scenario: Can I add one phone call and then process the phone call
// Expected Result: The phone call that was added should be connected
Console.WriteLine("Test 1");
PhoneSwitch phoneSwitch = new PhoneSwitch(5);
phoneSwitch.RequestCall("555-1234");
phoneSwitch.ProcessNextCall();
// Defect(s) Found: 

Console.WriteLine("=================");

// Test 2
// Scenario: Can I add three phone calls and then process them in the proper order
// Expected Result: The three phone calls should be connected in order from first to last
Console.WriteLine("Test 2");
phoneSwitch = new PhoneSwitch(5);
phoneSwitch.RequestCall("555-1234");
phoneSwitch.RequestCall("555-2468");
phoneSwitch.RequestCall("555-1379");
phoneSwitch.ProcessNextCall();
phoneSwitch.ProcessNextCall();
phoneSwitch.ProcessNextCall();
// Defect(s) Found: 

Console.WriteLine("=================");

// Test 3
// Scenario: If the queue has 2 phone calls in it already, will a 911 call be put in the front of the list
// Expected Result: The 911 call should be connected first then followed by the other 2 from first to last
Console.WriteLine("Test 3");
phoneSwitch = new PhoneSwitch(5);
phoneSwitch.RequestCall("555-1234");
phoneSwitch.RequestCall("555-2468");
phoneSwitch.RequestCall("911");
phoneSwitch.ProcessNextCall();
phoneSwitch.ProcessNextCall();
phoneSwitch.ProcessNextCall();
// Defect(s) Found: 

Console.WriteLine("=================");

// Test 4
// Scenario: Can I process a phone call if there are no phone calls in the queue
// Expected Result: This should display some error message
Console.WriteLine("Test 4");
phoneSwitch = new PhoneSwitch(5);
phoneSwitch.ProcessNextCall();
// Defect(s) Found: 

Console.WriteLine("=================");

// Test 5
// Scenario: TBD
// Expected Result: TDB
Console.WriteLine("Test 5");

// Defect(s) Found: 