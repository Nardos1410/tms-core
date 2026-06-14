public class EnrollmentService
{
    public EnrollmentRecord ProcessRegistration(Student? student, Course? course)
    {
        // Guard clause 1: Check for null student
        if (student is null)
            throw new ArgumentNullException(nameof(student), "Student cannot be null.");
        
        // Guard clause 2: Check for null course
        if (course is null)
            throw new ArgumentNullException(nameof(course), "Course cannot be null.");
        
        // Guard clause 3: Check if course capacity is valid
        if (course.Capacity <= 0)
            throw new InvalidOperationException("Course capacity must be greater than zero.");
        
        // Guard clause 4: Check if course is full - PUT IT HERE
        if (course.EnrolledCount >= course.Capacity)
            throw new CapacityReachedException(course.Code);
        
        // Switch expression to classify academic standing
        string standing = student.GPA switch
        {
            >= 3.5m => "Honors",
            >= 2.5m => "Good Standing",
            < 2.5m => "Academic Warning"
        };
        
        Console.WriteLine($"{student.Name} is in {standing}.");
        
        // Return new EnrollmentRecord
        return new EnrollmentRecord(student.Id, course.Code, DateTime.UtcNow);
    }
}