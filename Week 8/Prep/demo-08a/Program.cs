namespace demo_08a;

// CSE 212 Lesson 8A 
// Use recursion to display a word forward and backwards.
public static class Program {
    private static void DisplayForwards(string word) {
    }

    private static void DisplayBackwards(string word) {
    }

    private static int factorial(int n) {
        if (n == 0) {
            return 1;
        }
        return n * factorial(n - 1);
    }

    private static void Main() {
        DisplayForwards("Recursion");
        Console.WriteLine("=====================");
        DisplayBackwards("Recursion");

        Console.WriteLine(factorial(5));

        // Notes about array/string Slicing:

        // word[a..] - Index 'a' to the end
        // word[..a] = Index 0 to 'a' (not including 'a')
        // word[..] = Include everything (copy the array)
        // word[a..b] = Index 'a' to 'b' (not including 'b')

        // When slicing a list, it creates a new array.  A common trick
        // to copy an array is to do: newArray = array[..]
    }
}