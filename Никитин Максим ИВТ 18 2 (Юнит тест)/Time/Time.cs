using System;

namespace Time
{
    /// <summary>
    /// Класс Time представляет собой время выраенное в часах, минутах, секундах.
    /// Имеет четыре конструктора: Стандартый и три специальных.
    /// Специальный с одним параметром устанавливает часы.
    /// Специальный с двумя параметрами устанавливает часы и минуты.
    /// Специальный с тремя параметрами устанавливает часы, минуты и секунды.
    /// </summary>
    public class Time
    {
        sbyte second;
        sbyte minute;
        sbyte hour;

        /// <summary>
        /// Открытое свойство класса Time
        /// Представляет доступ к секундам
        /// Допустимые значения от 0 до 59
        /// </summary>
        public sbyte Second
        {
            get => second;
            set { second = (sbyte)((value <= 59 && value >= 0) ? value : 0); }
        }

        /// <summary>
        /// Открытое свойство класса Time
        /// Представляет доступ к минутам
        /// Допустимые значения от 0 до 59
        /// </summary>
        public sbyte Minute
        {
            get => minute;
            set { minute = (sbyte)((value <= 59 && value >= 0) ? value : 0); }
        }

        /// <summary>
        /// Открытое свойство класса Time
        /// Представляет доступ к часам
        /// Допустимые значения от 0 до 23
        /// </summary>
        public sbyte Hour
        {
            get => hour;
            set { hour = (sbyte)((value <= 23 && value >= 0) ? value : 0); }
        }

        /// <summary>
        /// Открытый констрктор класса Time
        /// </summary>
        public Time(sbyte h = 0, sbyte m = 0, sbyte s = 0)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }



        /// <summary>
        /// Открытый оператор класса Time
        /// Складывает два экземпляра класса Time по правилаь складывания времени
        /// </summary>
        public static Time operator +(Time t1, Time t2)
        {
            Time Res = new Time();
            Res.hour = (sbyte)(t1.hour + t2.hour);
            Res.minute = (sbyte)(t1.minute + t2.minute);
            Res.second = (sbyte)(t1.second + t2.second);

            if (Res.second > 59)
            {
                Res.second -= 60;
                Res.minute++;
            }
            if (Res.minute > 59)
            {
                Res.minute -= 60;
                Res.hour++;
            }
            Res.hour = (sbyte)((Res.Hour > 23) ? Res.hour - 24 : Res.hour);

            return Res;
        }

        /// <summary>
        /// Открытый оператор класса Time
        /// Вычитает два экземпляра класса Time по правилам вычитания времени
        /// </summary>
        public static Time operator -(Time t1, Time t2)
        {
            Time Res = new Time();
            Res.hour = (sbyte)(t1.hour - t2.hour);
            Res.minute = (sbyte)(t1.minute - t2.minute);
            Res.second = (sbyte)(t1.second - t2.second);

            if (Res.second < 0)
            {
                Res.second += 60;
                Res.minute--;
            }
            if (Res.minute < 0)
            {
                Res.minute += 60;
                Res.hour--;
            }
            Res.hour = (sbyte)((Res.hour < 0) ? Res.hour + 24 : Res.hour);

            return Res;
        }



        /// <summary>
        /// Открытый метод класса Time
        /// Переводит текущее время в часы
        /// </summary>
        public float ToHour => hour + (minute / 60.0f);

        /// <summary>
        /// Открытый метод класса Time
        /// Переводит текущее время в минуты
        /// </summary>
        public float ToMinute => (hour * 60) + minute + (second / 60.0f);

        /// <summary>
        /// Открытый метод класса Time
        /// Переводит текущее время в секунды 
        /// </summary>
        public float ToSecond => (hour * 3600.0f) + (minute * 60) + second;

        /// <summary>
        /// Переопределенный метод базового класса System.Object 
        /// Возвращает состояние класса Time в формате строки
        /// </summary>
        public override string ToString() => $"[{hour}:{minute}:{second}]";



        /// <summary>
        /// Открытый метод класса Time
        /// Увеличивает текущее время на h часов
        /// </summary>
        public void Add_H(uint h)
        {
            long AddH = hour + h;

            while (AddH > 23)
                AddH -= 24;

            hour = (sbyte)AddH;
        }

        /// <summary>
        /// Открытый метод класса Time
        /// Увеличивает текущее время на m минут
        /// </summary>
        public void Add_M(uint m)
        {
            long AddM = minute + m;
            uint h = 0;

            while (AddM > 59)
            {
                AddM -= 60;
                h++;
            }
            minute = (sbyte)AddM;
            Add_H(h);
        }

        /// <summary>
        /// Открытый метод класса Time
        /// Увеличивает текущее время на s секунд
        /// </summary>
        public void Add_S(uint s)
        {
            long AddS = second + s;
            uint m = 0;
            while (AddS > 59)
            {
                AddS -= 60;
                m++;
            }

            second = (sbyte)AddS;
            Add_M(m);
        }



        /// <summary>
        /// Открытый метод класса Time
        /// Уменьшает текущее время на h часов
        /// </summary>
        public void Sub_H(uint h)
        {
            long SubH = hour - h;
            while (SubH < 0)
                SubH += 24;

            hour = (sbyte)SubH;
        }

        /// <summary>
        /// Открытый метод класса Time
        /// Уменьшает текущее время на m минут
        /// </summary>
        public void Sub_M(uint m)
        {
            long SubM = minute - m;
            uint h = 0;

            while (SubM < 0)
            {
                SubM += 60;
                h++;
            }
            minute = (sbyte)SubM;
            Sub_H(h);
        }

        /// <summary>
        /// Открытый метод класса Time
        /// Уменьшает текущее время на s секунд
        /// </summary>
        public void Sub_S(uint s)
        {
            long SubS = second - s;
            uint m = 0;

            while (SubS < 0)
            {
                SubS += 60;
                m++;
            }
            second = (sbyte)SubS;
            Sub_M(m);
        }



        /// <summary>
        /// Открытый оператор класса Time
        /// Сравнивает два экземпляра класса Time на равенство
        /// </summary>
        public static bool operator ==(Time t1, Time t2) =>
            (t1.hour == t2.hour && t1.minute == t2.minute && t1.second == t2.second) ? true : false;

        /// <summary>
        /// Открытый оператор класса Time
        /// Сравнивает два экземпляра класса Time на неравенство
        /// </summary>
        public static bool operator !=(Time t1, Time t2) =>
            (!(t1 == t2));

        /// <summary>
        /// Открытый оператор класса Time
        /// Вернет true если правый операнд больше левого
        /// </summary>
        public static bool operator >(Time t1, Time t2)
        {
            if (t1.hour > t2.hour) return true;
            if (t1.hour == t2.hour)
            {
                if (t1.minute > t2.minute) return true;
                if (t1.minute == t2.minute && t1.second > t2.second) return true;
            }
            return false;
        }

        /// <summary>
        /// Открытый оператор класса Time
        /// Вернет true если правый операнд меньше левого
        /// </summary>
        public static bool operator <(Time t1, Time t2) =>
            (!(t1 > t2) && (t1 != t2));

        /// <summary>
        /// Открытый оператор класса Time
        /// Вернет true если правый операнд меньше либо равен левому
        /// </summary>
        public static bool operator <=(Time t1, Time t2) =>
            (t1 == t2 || t1 < t2);

        /// <summary>
        /// Открытый оператор класса Time
        /// Вернет true если правый операнд больше либо равен левому
        /// </summary>
        public static bool operator >=(Time t1, Time t2) =>
            (t1 == t2 || t1 > t2);

        /// <summary>
        /// Возврат текущего времени. 
        /// </summary>
        public static Time Now 
        {
            get
            {
                DateTime time = DateTime.Now;
                return new Time((sbyte)time.Hour, (sbyte)time.Minute, (sbyte)time.Second);
            }
        }
    }
}   
    