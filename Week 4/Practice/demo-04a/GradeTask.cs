namespace demo_04a; 

public class GradeTask {
    private string _course;
    private string _project;
    private string _studentId;

    public GradeTask(string course, string project, string studentId) {
        _course = course;
        _project = project;
        _studentId = studentId;
    }

    override public string ToString() {
        return $"{_course} - {_project} for {_studentId}.";
    }

    public void Display() {
        Console.WriteLine(this);
    }

    public void Grade() {
        this.Display();
        Console.WriteLine("Everyone gets an A!");
    }
}