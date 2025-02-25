namespace demo_03a;

public static class Train {
    public static void Run() {
        var mainLine = new Stack<string>(new[] { "F", "E", "D", "C", "B", "A" });
        var sideLine = new Stack<string>();
        var keepGoing = true;

        while (keepGoing) {
            Console.Clear();
            DrawTracks();
            DrawTrain(mainLine, 0);
            DrawTrain(sideLine, 1);
            DrawMenu();

            var consoleKeyInfo = Console.ReadKey(true);
            var command = consoleKeyInfo.KeyChar;

            if (command == 'm') {
                // Move car to the side line using stack operations

                
            }
            else if (command == 'r') {
                // Move car back to the main line using stack operations
            }
            else if (command == 'q') {
                keepGoing = false;
                Console.Write("Quitting...");
            }
        }
    }

    private static void DrawTrain(Stack<string> cars, int track) {
        var carCount = 1;
        foreach (var carLabel in cars) {
            DrawCar(carLabel, cars.Count - carCount++, track);
        }
    }

    private static void DrawCar(string carLabel, int position, int track) {
        DrawString(position * 9, track * 6, "/-----\\");
        DrawString(position * 9, track * 6 + 1, $"|  {carLabel}  |--");
        DrawString(position * 9, track * 6 + 2, "\\-----/");
        DrawString(position * 9, track * 6 + 3, "()   ()");
    }

    private static void DrawMenu() {
        DrawString(0, 12, "m: move car to side line");
        DrawString(0, 13, "r: return car to main line");
        DrawString(0, 14, "q: quit");
        Console.SetCursorPosition(0, 15);
    }

    private static void DrawTracks() {
        DrawString(0, 4, new string('=', 80));
        DrawString(0, 10, new string('=', 56));
        DrawString(64, 5, "//");
        DrawString(62, 6, "//");
        DrawString(60, 7, "//");
        DrawString(58, 8, "//");
        DrawString(56, 9, "//");
    }

    private static void DrawString(int left, int top, string str) {
        Console.SetCursorPosition(left, top);
        Console.Write(str);
    }
}