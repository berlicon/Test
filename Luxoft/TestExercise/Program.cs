﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestExercise.Generator;

namespace TestExercise
{
    partial class Program
    {
        //  Я, как пользователь, хочу,
        //  * чтобы рядом с пином каждого сотрудника, чей Пин делиться без остатка на 7, отображалось слово WithBonus,
        //  * если делиться на 3 - Fired,
        //  * а если делиться без остатка и на 3 и на 7, то должно выводиться только слово FiredWithBonus.
        //  * сотрудники, чей пин не делиться ни на одно из этих чисел - выводиться не должны.

        /*
            Бизнесу понравилась решение вашей предыдущей задачи. И теперь они хотят использовать аналогичную логику в другом месте.
         */
        static void Main(string[] args)
        {
            var employees = new EmployeeGenerator().GetEmployees().ToList();
            PrintEmployeesList(employees);
        }

        static void PrintEmployeesList(List<Employee> employees)
        {
            employees.ForEach(r =>
            {
                var info = GetEmployeeInfo(r, 7, 3);
                var info2 = GetEmployeeInfo(r, 4, 5);
                if (info != null)
                {
                    Console.WriteLine($"Pin {r.Pin} {info} {r.FirstName} {r.SecondName}");
                }
                if (info2 != null)
                {
                    Console.WriteLine($"Pin {r.Pin} {info2} {r.FirstName} {r.SecondName}");
                }
            });
        }

        static string GetEmployeeInfo(Employee employee, int num1 = 7, int num2 = 3)
        {
            if (!(employee.Pin % num1 == 0 || employee.Pin % num2 == 0))
            {
                return null;
            }
            else if (employee.Pin % num1 == 0 && employee.Pin % num2 == 0)
            {
                return "FiredWithBonus";
            }
            else if (employee.Pin % num1 == 0)
            {
                return "WithBonus";
            }
            else {
                return "Fired";
            }
        }

    }
}