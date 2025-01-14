Öğrenci ve Ders Yönetim Sistemi
Proje Özeti
Bu proje, C# programlama dili kullanılarak geliştirilmiş bir Öğrenci ve Ders Yönetim Sistemi konsol uygulamasıdır. Uygulama, öğrenci, öğretim görevlisi ve ders bilgilerinin yönetimini sağlar. Tüm kayıtlar JSON dosyalarında saklanır ve dosyalardan okunarak işlenir. Proje, temel nesne yönelimli programlama (OOP) kavramlarını (kalıtım, çok biçimlilik, arayüz kullanımı gibi) uygulamalı olarak göstermektedir.

Özellikler
Sınıflar ve Kalıtım:
Person adlı temel sınıf, Student (Öğrenci) ve Instructor (Öğretim Görevlisi) sınıfları tarafından miras alınmıştır.
Arayüz Kullanımı:
ILogin adlı arayüz, Student ve Instructor sınıflarında uygulanmıştır.
Ders Yönetimi:
Dersler; ders adı, kredi, öğretim görevlisi ve kayıtlı öğrenciler gibi bilgileri içerir.
Öğrenciler derslere kaydedilebilir ve sınav notları eklenebilir.
Dosya İşlemleri:
Öğrenci, öğretim görevlisi ve ders bilgileri yerel JSON dosyalarına kaydedilir ve buradan okunur.
Konsol Uygulaması:
Kullanıcıdan alınan girişler ile veri ekleme, listeleme ve güncelleme işlemleri yapılabilir.
Gereksinimler
Bu projeyi çalıştırmak için aşağıdaki yazılımlar gereklidir:

.NET 6.0 veya daha yeni bir sürüm
Geliştirme ortamı (ör. Visual Studio, Rider veya VS Code)
Kullanım Talimatları
Projeyi Çalıştırma:
Proje dosyalarını indirip yerel bir klasöre kaydedin.
Uygulama, Main() metodu üzerinden çalıştırılabilir.
Veri Girişi:
Öğrenci, öğretim görevlisi ve ders bilgileri konsol üzerinden girilir.
Girdiğiniz bilgiler yerel JSON dosyalarına kaydedilir.
Dosya Kayıtları:
Öğrenci bilgileri: students.json
Öğretim görevlisi bilgileri: instructors.json
Ders bilgileri: courses.json
Örnek Çıktı
text
Kodu kopyala
Welcome to the Course Management System!

Enter Instructor Name: Dr. Ahmet Yılmaz
Enter Instructor Email: ahmet.yilmaz@example.com

Enter Course Name: Mathematics 101
Enter Course Credits: 3

Enter Number of Students to Enroll: 2
Student 1:
Enter Student Number: 12345
Enter Student Name: Ali Veli
Enter Student Email: ali.veli@example.com
Enter Exam Score for Ali Veli in Mathematics 101: 85

Student 2:
Enter Student Number: 67890
Enter Student Name: Ayşe Demir
Enter Student Email: ayse.demir@example.com
Enter Exam Score for Ayşe Demir in Mathematics 101: 90

Course Details:
Course Name: Mathematics 101, Credits: 3, Instructor: Dr. Ahmet Yılmaz
Enrolled Students and Exam Scores:
- Ali Veli (Student Number: 12345), Exam Score: 85
- Ayşe Demir (Student Number: 67890), Exam Score: 90
Katkıda Bulunma
Bu projeye katkıda bulunmak için:

Projeyi forklayın.
Yeni bir dal (branch) oluşturun: git checkout -b yeni-ozellik.
Değişikliklerinizi yapın ve commit edin: git commit -m "Yeni özellik eklendi".
Dalınızı uzak depoya push edin: git push origin yeni-ozellik.
Bir Pull Request oluşturun.
