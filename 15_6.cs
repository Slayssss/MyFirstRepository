using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace WorkWithFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            // ��������� ��������
            phoneBook.Add(new Contact("�����", "��������", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("������", "��������", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("��������", "������", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("�������", "��������", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("������", "����", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("����������", "�������������", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar; // �������� ������ � �������

                var parsed = Int32.TryParse(keyChar.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("�������� �� ����������");
                }
                else
                {
                    var pageContent = phoneBook.OrderBy(pers => pers.Name).ThenBy(pers => pers.LastName).Skip( (pageNumber - 1) * 2).Take(2);
                    Console.WriteLine();

                    // ����� ���������� �� �������
                    foreach (var contact in pageContent)
                        Console.WriteLine($"{contact.Name} : {contact.LastName} : {contact.Email} : {contact.PhoneNumber}");
                }
            }
        }
    }

    public class Contact // ������ ������
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // �����-�����������
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}
