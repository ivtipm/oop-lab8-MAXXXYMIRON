//using Time;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Time.tests
{
    /*
     1)Что такое юнит-тест?
        Блок кода, которой вызывает другой блок кода(функция, метод, процедура),
        ожидая от него известный, при некоторых парамметрах, результат работы.
        Если результат не совпал с ожидаемым считается, что юнит-тест не пройден.

     2)Для чего нужны юнит-тесты, в чем их преимущество?
        Юнит-тесты нужны для предотвращения ошибок в методах и проверки корректности
        выдаваемых результатов, при некоторых парамметрах. 
        - Написание юнит-тестов и тестирование с из помощью быстрее, чем без них.
        - Обнаружить ошибку гараздо легче при модульном тестировании, тем более, если тело метода 
        часто меняется.
        - При модульном тестировании можно выявить недостатки GUI программы.
        - Программа прошедшая модульное тестирование, с наименьшей вероятностью выдаст ошибки,
        при использовании.
        - Все ошибки обнаруживаются в контролируемом эксперименте.

     3)Что такое Test Driven Development?
        TDD - Test Driven Development(Разработка через Тестирование)
        Прежде чем писать функцию для нее пишется юнит-тест, после чего
        нужно написать такое определение функции, чтобы она проша все тесты,
        как только функция будет проходить все тесты, над ней проводится рефакторинг
        и пишется новый тест для след. функции.
        Данный процесс цикличен и описывается след. послед. действий:
        Написать тест -> Запустить тест -> Написать функцию -> Запустить тест -> Рефакторинг -> Первый шаг

     4)Приведите пример когда создание юнит-тест оправдано и когда нет.
        Когда стоит.
        Юнит тесты лучше писить для либо очень сложного кода, который почти не имеет зависимостей
        от работы других методов или параметров других сущностей, либо когда код не очень 
        сложный, но при этом имеет какие-то зависимости.
        Когда не стоит.
        Когда код очень простой и даже не имеет зависимостей или кода код имеет очень много
        зависимостей, так как сложно будет определить из-за чего происходит ошибка. Возможно,
        сигнатура методов кода будет менятся, так как для проведения юнит-тестов необходимо будет 
        провести рефакторинг кода.
    */


    [TestClass]
    public class TimeTests
    {
        Time Actual = new Time();

        [TestMethod]
        public void Second__SecondAssign_100__Second_0()
        {
            Actual.Second = 100;
            Assert.AreEqual(0, Actual.Second, "При значении 100, значение Second = 0");
        }
        [TestMethod]
        public void Second__SecondAssignMinus_1__Second_0()
        {
            Actual.Second = -1;
            Assert.AreEqual(0, Actual.Second, "При значении -1, значение Second = 0");
        }
        [TestMethod]
        public void Second__SecondAssign_50__Second_50()
        {
            Actual.Second = 50;
            Assert.AreEqual(50, Actual.Second, "При значении 50, значение Second = 50");
        }


        [TestMethod]
        public void Minute__MinuteAssign_100__Minute_0()
        {
            Actual.Minute = 100;
            Assert.AreEqual(0, Actual.Minute, "При значении 100, значение Minute = 0");
        }
        [TestMethod]
        public void Minute__MinuteAssignMinus_1__Minute_0()
        {
            Actual.Minute = -1;
            Assert.AreEqual(0, Actual.Minute, "При значении -1, значение Minute = 0");
        }
        [TestMethod]
        public void Minute__MinuteAssign_50__Minute_50()
        {
            Actual.Minute = 50;
            Assert.AreEqual(50, Actual.Minute, "При значении 50, значение Minute = 50");
        }

        [TestMethod]
        public void Hour__HourAssign_25__Hour_0()
        {
            Actual.Hour = 25;
            Assert.AreEqual(0, Actual.Hour, "При значении 25, значение Hour = 0");
        }
        [TestMethod]
        public void Hour__HourAssignMinus_1__Hour_0()
        {
            Actual.Hour = -1;
            Assert.AreEqual(0, Actual.Hour, "При значении 1, значение Hour = 0");
        }
        [TestMethod]
        public void Hour__HourAssign_20__Hour_20()
        {
            Actual.Hour = 20;
            Assert.AreEqual(20, Actual.Hour, "При значении 20, значение Hour = 20");
        }


        [TestMethod]
        public void ToHour__0_59_59_ToHour__returned_0point98()
        {
            Actual = new Time(0, 59, 59);
            float Expected = 0.98f;

            Assert.AreEqual(Expected, Actual.ToHour, 0.0034, "ToHour вернет 0.98 часов при {0} часов в экземпляре", Actual.ToString());
        }
        [TestMethod]
        public void ToHour__9_0_59_ToHour__returned_9()
        {
            Actual = new Time(9, 0, 59);
            Assert.AreEqual(9, Actual.ToHour, "ToHour вернет 9 часов при {0} часов в экземпляре", Actual.ToString());
        }


        [TestMethod]
        public void ToMinute__0_10_20_ToMinute__returned_10point33()
        {
            Actual = new Time(0, 10, 20);
            float Expected = 10.33f;

            Assert.AreEqual(Expected, Actual.ToMinute, 0.0034, "ToMinute вернет 0.33 минут при {0} часов в экземпляре", Actual.ToString());
        }
        [TestMethod]
        public void ToMinute__0_10_0_ToMinute__returned_10()
        {
            Actual = new Time(0, 10, 0);
            float Expected = 10;

            Assert.AreEqual(Expected, Actual.ToMinute, "ToMinute вернет 10 минут при {0} часов в экземпляре", Actual.ToString());
        }
        [TestMethod]
        public void ToMinute__10_10_0_ToMinute__returned_610()
        {
            Actual = new Time(10, 10, 0);
            float Expected = 610;

            Assert.AreEqual(Expected, Actual.ToMinute, "ToMinute вернет 610 минут при {0} часов в экземпляре", Actual.ToString());
        }


        [TestMethod]
        public void ToSecond__10_10_10_ToSecond__returned_36610()
        {
            Actual = new Time(10, 10, 10);
            int Expexted = 36610;

            Assert.AreEqual(Expexted, Actual.ToSecond, "При {0} часов ToSecond вернет 36610с", Actual.ToString());
        }


        [TestMethod]
        public void Add_H__23_59_59_Add_1_Hour__returned_0_59_59()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(0, 59, 59);

            Actual.Add_H(1);
            Assert.AreEqual(Expected.ToString(), Actual.ToString(), "23:59:59 + 1 час = {0}", Expected.ToString());
        }
        [TestMethod]
        public void Add_H__0_0_0_Add_40_Hours__returned_16_0_0()
        {
            Actual = new Time(0, 0, 0);
            Time Expected = new Time(16, 0, 0);

            Actual.Add_H(40);
            Assert.AreEqual(Expected.ToString(), Actual.ToString(), "0:0:0 + 40 часов = {0}", Expected.ToString());
        }
        [TestMethod]
        public void Add_H__0_0_0_Add_24_Hours__returned_0_0_0()
        {
            Actual = new Time(0, 0, 0);
            Time Expected = new Time(0, 0, 0);

            Actual.Add_H(24);
            Assert.AreEqual(Expected.ToString(), Actual.ToString(), "0:0:0 + 24 часа = {0}", Expected.ToString());
        }


        [TestMethod]
        public void Add_M__23_59_59__Add_1_Minute__returned_0_0_59()
        {
            Actual = new Time(23, 59, 59);
            Time Expexted = new Time(0, 0, 59);

            Actual.Add_M(1);

            Assert.AreEqual(Expexted.ToString(), Actual.ToString(), $"23:59:59 pluse 1 minute == {Expexted.ToString()}");
        }
        [TestMethod]
        public void Add_M__22_50_0__Add_135_Minute__returned_1_5_0()
        {
            Actual = new Time(22, 50, 0);
            Time Expexted = new Time(1, 5, 0);

            Actual.Add_M(135);

            Assert.AreEqual(Expexted.ToString(), Actual.ToString(), $"20:50:0 pluse 135 minute == {Expexted.ToString()}");
        }
        [TestMethod]
        public void Add_M__22_50_0__Add_1440_Minute__returned_22_50_0()
        {
            Actual = new Time(22, 50, 0);
            Time Expexted = new Time(22, 50, 0);

            Actual.Add_M(1440);

            Assert.AreEqual(Expexted.ToString(), Actual.ToString(), $"20:50:0 pluse 1440 minute == {Expexted.ToString()}");
        }


        [TestMethod]
        public void Add_S__23_59_59__Add_1_sec__returned_0_0_0()
        {
            Actual = new Time(23, 59, 59);
            Time Expexted = new Time(0, 0, 0);
            uint add = 1;

            Actual.Add_S(add);

            Assert.AreEqual(Expexted.ToString(), Actual.ToString(), $"23:59:59 + {add} sec == {Expexted.ToString()}");
        }
        [TestMethod]
        public void Add_S__23_50_50__Add_7810_sec__returned_2_1_0()
        {
            Actual = new Time(23, 50, 50);
            Time Expexted = new Time(2, 1, 0);
            uint add = 7810;

            Actual.Add_S(add);

            Assert.AreEqual(Expexted.ToString(), Actual.ToString(), $"23:50:50 + {add} sec == {Expexted.ToString()}");
        }


        [TestMethod]
        public void OperatorPlus__23_50_50_plus_0_9_10__returned_0_0_0()
        {
            Time Left = new Time(23, 50, 50),
                Right = new Time(0, 9, 10),
                Expected = new Time();

            Actual = Left + Right;

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"{Left} + {Right} == {Expected}");
        }
        [TestMethod]
        public void OperatorPlus__20_59_59_plus_20_0_1__returned_17_0_0()
        {
            Time Left = new Time(20, 59, 59),
                Right = new Time(20, 0, 1),
                Expected = new Time(17);

            Actual = Left + Right;

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"{Left} + {Right} == {Expected}");
        }


        [TestMethod]
        public void OperatorMinus__23_50_50_minus_23_50_50__returned_0_0_0()
        {
            Time Left = new Time(23, 50, 50),
                Right = new Time(23, 50, 50),
                Expected = new Time();

            Actual = Left - Right;

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"{Left} - {Right} == {Expected}");
        }
        [TestMethod]
        public void OperatorMinus__23_0_50_minus_0_1_0__returned_22_59_0()
        {
            Time Left = new Time(23, 0, 50),
                Right = new Time(0, 1, 0),
                Expected = new Time(22, 59, 50);

            Actual = Left - Right;

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"{Left} - {Right} == {Expected}");
        }
        [TestMethod]
        public void OperatorMinus__0_0_0_minus_1_1_1__returned_22_58_59()
        {
            Time Left = new Time(0, 0, 0),
                Right = new Time(1, 1, 1),
                Expected = new Time(22, 58, 59);

            Actual = Left - Right;

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"{Left} - {Right} == {Expected}");
        }


        [TestMethod]
        public void Sub_H__0_0_0_Sub_1_Hour__returned_23_0_0()
        {
            Actual = new Time();
            uint sub = 1;
            Time Expected = new Time(23);

            Actual.Sub_H(sub);

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"0:0:0 - {sub} hour == {Expected}");
        }
        [TestMethod]
        public void Sub_H__0_0_0_Sub_72_Hour__returned_0_0_0()
        {
            Actual = new Time();
            uint sub = 72;
            Time Expected = new Time();

            Actual.Sub_H(sub);

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"0:0:0 - {sub} hour == {Expected}");
        }


        [TestMethod]
        public void Sub_M__0_0_0_Sub_1_Minute__returned_23_59_0()
        {
            Actual = new Time();
            uint sub = 1;
            Time Expected = new Time(23, 59, 0);

            Actual.Sub_M(sub);

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"0:0:0 - {sub} hour == {Expected}");
        }
        [TestMethod]
        public void Sub_M__10_1_0_Sub_1_Minute__returned_10_0_0()
        {
            Actual = new Time(10, 1);
            uint sub = 1;
            Time Expected = new Time(10);

            Actual.Sub_M(sub);

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"0:0:0 - {sub} hour == {Expected}");
        }
        [TestMethod]
        public void Sub_M__10_34_12_Sub_4320_Minute__returned_10_34_12()
        {
            Actual = new Time(10, 34, 12);
            uint sub = 4320;
            Time Expected = new Time(10, 34, 12);

            Actual.Sub_M(sub);

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"0:0:0 - {sub} hour == {Expected}");
        }


        [TestMethod]
        public void Sub_S__10_34_12_Sub_259200_sec__returned_10_34_12()
        {
            Actual = new Time(10, 34, 12);
            uint sub = 259200;
            Time Expected = new Time(10, 34, 12);

            Actual.Sub_S(sub);

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"0:0:0 - {sub} hour == {Expected}");
        }
        [TestMethod]
        public void Sub_S__0_0_0_Sub_1_sec__returned_23_59_59()
        {
            Actual = new Time();
            uint sub = 1;
            Time Expected = new Time(23, 59, 59);

            Actual.Sub_S(sub);

            Assert.AreEqual(Expected.ToString(), Actual.ToString(), $"0:0:0 - {sub} hour == {Expected}");
        }


        [TestMethod]
        public void Equal__23_59_59_Equal_23_59_59__returned_true()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(23, 59, 59);

            Assert.IsTrue((Actual == Expected), $"{Actual} == {Expected}");
        }
        [TestMethod]
        public void Equal__23_59_59_Equal_23_58_59__returned_false()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(23, 58, 59);

            Assert.IsFalse((Actual == Expected), $"{Actual} !== {Expected}");
        }


        [TestMethod]
        public void NotEqual__23_59_59_NotEqual_23_59_59__returned_false()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(23, 59, 59);

            Assert.IsFalse((Actual != Expected), $"{Actual} !!= {Expected}");
        }
        [TestMethod]
        public void NotEqual__23_59_59_NotEqual_23_58_59__returned_true()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(23, 58, 59);

            Assert.IsTrue((Actual != Expected), $"{Actual} != {Expected}");
        }


        [TestMethod]
        public void More__23_59_59_more_0_3_3__returned_true()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(m:3, s:3);

            Assert.IsTrue((Actual > Expected), $"{Actual} > {Expected}");
        }
        [TestMethod]
        public void More__0_3_3_more_23_59_59__returned_false()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(23, 59, 59);

            Assert.IsFalse((Actual > Expected), $"{Actual} !> {Expected}");
        }
        [TestMethod]
        public void More__0_3_3_more_0_3_3__returned_false()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(m: 3, s: 3);

            Assert.IsFalse((Actual > Expected), $"{Actual} !> {Expected}");
        }



        [TestMethod]
        public void Less__0_3_3_less_23_59_59__returned_true()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(23, 59, 59);

            Assert.IsTrue((Actual < Expected), $"{Actual} < {Expected}");
        }
        [TestMethod]
        public void Less__0_3_3_less_0_3_3__returned_false()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(m: 3, s: 3);

            Assert.IsFalse((Actual < Expected), $"{Actual} !< {Expected}");
        }
        [TestMethod]
        public void Less__23_59_59_less_0_3_3__returned_false()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(m: 3, s: 3);

            Assert.IsFalse((Actual < Expected), $"{Actual} !< {Expected}");
        }


        [TestMethod]
        public void MoreOrEqual__0_3_3_MoreOrEqual_23_59_59__returned_false()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(23, 59, 59);

            Assert.IsFalse((Actual >= Expected), $"{Actual} !>= {Expected}");
        }
        [TestMethod]
        public void MoreOrEqual__0_3_3_MoreOrEqual_0_3_3__returned_true()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(m: 3, s: 3);

            Assert.IsTrue((Actual >= Expected), $"{Actual} >= {Expected}");
        }
        [TestMethod]
        public void MoreOrEqual__23_59_59_MoreOrEqual_0_3_3__returned_true()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(m: 3, s: 3);

            Assert.IsTrue((Actual >= Expected), $"{Actual} >= {Expected}");
        }



        [TestMethod]
        public void LessOrEqual__0_3_3_LessOrEqual_23_59_59__returned_true()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(23, 59, 59);

            Assert.IsTrue((Actual <= Expected), $"{Actual} <= {Expected}");
        }
        [TestMethod]
        public void LessOrEqual__0_3_3_LessOrEqual_0_3_3__returned_true()
        {
            Actual = new Time(m: 3, s: 3);
            Time Expected = new Time(m: 3, s: 3);

            Assert.IsTrue((Actual <= Expected), $"{Actual} <= {Expected}");
        }
        [TestMethod]
        public void LessOrEqual__23_59_59_LessOrEqual_0_3_3__returned_false()
        {
            Actual = new Time(23, 59, 59);
            Time Expected = new Time(m: 3, s: 3);

            Assert.IsFalse((Actual <= Expected), $"{Actual} !<= {Expected}");
        }
    }
}
