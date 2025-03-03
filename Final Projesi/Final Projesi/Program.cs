﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json; // JSON işlemleri için
using System.Xml.Serialization; // XML işlemleri için

// Base class
public abstract class Person
{
    public string Name { get; set; }
    public string Email { get; set; }

    public abstract void DisplayInfo();
}

// Interface
public interface ILogin
{
    void Login();
}

// Derived classes
public class Student : Person, ILogin
{
    public int StudentNumber { get; set; }
    public List<Course> EnrolledCourses { get; set; } = new List<Course>();
    public Dictionary<Course, double> ExamScores { get; set; } = new Dictionary<Course, double>();

    public override void DisplayInfo()
    {
        Console.WriteLine($"Student Number: {StudentNumber}, Name: {Name}, Email: {Email}");
    }

    public void Login()
    {
        Console.WriteLine($"{Name} (Student) has logged in.");
    }

    public void AddExamScore(Course course, double score)
    {
        ExamScores[course] = score;
    }
}

public class Instructor : Person, ILogin
{
    public List<Course> TaughtCourses { get; set; } = new List<Course>();

    public override void DisplayInfo()
    {
        Console.WriteLine($"Instructor Name: {Name}, Email: {Email}");
    }

    public void Login()
    {
        Console.WriteLine($"{Name} (Instructor) has logged in.");
    }
}

// Course class
public class Course
{
    public string CourseName { get; set; }
    public int Credits { get; set; }
    public Instructor CourseInstructor { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new List<Student>();

    public void DisplayCourseInfo()
    {
        Console.WriteLine($"Course Name: {CourseName}, Credits: {Credits}, Instructor: {CourseInstructor.Name}");
        Console.WriteLine("Enrolled Students and Exam Scores:");
        foreach (var student in EnrolledStudents)
        {
            var score = student.ExamScores.ContainsKey(this) ? student.ExamScores[this] : 0.0;
            Console.WriteLine($"- {student.Name} (Student Number: {student.StudentNumber}), Exam Score: {score}");
        }
    }
}

// File Operations Helper
public static class FileHelper
{
    public static void SaveToJson<T>(string filePath, List<T> data)
    {
        var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonData);
    }

    public static List<T> LoadFromJson<T>(string filePath)
    {
        if (!File.Exists(filePath)) return new List<T>();
        var jsonData = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(jsonData);
    }

    public static void SaveToXml<T>(string filePath, List<T> data)
    {
        var serializer = new XmlSerializer(typeof(List<T>));
        using var writer = new StreamWriter(filePath);
        serializer.Serialize(writer, data);
    }

    public static List<T> LoadFromXml<T>(string filePath)
    {
        if (!File.Exists(filePath)) return new List<T>();
        var serializer = new XmlSerializer(typeof(List<T>));
        using var reader = new StreamReader(filePath);
        return (List<T>)serializer.Deserialize(reader);
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        const string studentFile = "students.json";
        const string instructorFile = "instructors.json";
        const string courseFile = "courses.json";

        var students = FileHelper.LoadFromJson<Student>(studentFile);
        var instructors = FileHelper.LoadFromJson<Instructor>(instructorFile);
        var courses = FileHelper.LoadFromJson<Course>(courseFile);

        Console.WriteLine("Welcome to the Course Management System!");

        // Instructor
        Console.Write("Enter Instructor Name: ");
        string instructorName = Console.ReadLine();
        Console.Write("Enter Instructor Email: ");
        string instructorEmail = Console.ReadLine();

        var instructor = new Instructor { Name = instructorName, Email = instructorEmail };
        instructors.Add(instructor);

        // Course
        Console.Write("Enter Course Name: ");
        string courseName = Console.ReadLine();
        Console.Write("Enter Course Credits: ");
        int credits = int.Parse(Console.ReadLine());

        var course = new Course { CourseName = courseName, Credits = credits, CourseInstructor = instructor };
        courses.Add(course);
        instructor.TaughtCourses.Add(course);

        // Students
        Console.Write("Enter Number of Students to Enroll: ");
        int numberOfStudents = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfStudents; i++)
        {
            Console.WriteLine($"Student {i + 1}:");
            Console.Write("Enter Student Number: ");
            int studentNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter Student Email: ");
            string studentEmail = Console.ReadLine();

            var student = new Student { StudentNumber = studentNumber, Name = studentName, Email = studentEmail };
            students.Add(student);

            Console.Write($"Enter Exam Score for {studentName} in {courseName}: ");
            double examScore = double.Parse(Console.ReadLine());
            student.AddExamScore(course, examScore);
            course.EnrolledStudents.Add(student);
        }

        // Save data to files
        FileHelper.SaveToJson(studentFile, students);
        FileHelper.SaveToJson(instructorFile, instructors);
        FileHelper.SaveToJson(courseFile, courses);

        // Display course info
        Console.WriteLine("\nCourse Details:");
        course.DisplayCourseInfo();
    }
}
