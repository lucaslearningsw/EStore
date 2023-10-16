using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EStore.Core.DomainObjects
{
    public class Validations
    {
        public static void ValidateIsEqual(object object1, object object2, string mensage)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateIsDifferent(object object1, object object2, string mensage)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateSize(string value, int max, string mensage)
        {
            var lentgh = value.Trim().Length;
            if (lentgh > max)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateSize(string value, int min, int max, string mensage)
        {
            var lentgh = value.Trim().Length;
            if (lentgh < min || lentgh > max)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateExpression(string pattern, string value, string mensage)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateIsNull(string value, string mensage)
        {
            if (value == null || value.Trim().Length == 0)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateIsNull(object object1, string mensage)
        {
            if (object1 == null)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateMinMax(double value, double min, double max, string mensage)
        {
            if (value < min || value > max)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateMinMax(float value, float min, float max, string mensage)
        {
            if (value < min || value > max)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateMinMax(int value, int min, int max, string mensage)
        {
            if (value < min || value > max)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateMinMax(long value, long min, long max, string mensage)
        {
            if (value < min || value > max)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateMinMax(decimal value, decimal min, decimal max, string mensage)
        {
            if (value < min || value > max)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateLessThan(decimal value, decimal min, string mensage)
        {
            if (value < min)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateLessThan(int value, int min, string mensage)
        {
            if (value < min)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateLessThan(long value, long min, string mensage)
        {
            if (value < min)
            {
                throw new DomainException(mensage);
            }
        }


        public static void ValidateLessThan(double value, double min, string mensage)
        {
            if (value < min)
            {
                throw new DomainException(mensage);
            }
        }


        public static void ValidateIsFalse(bool value, string mensage)
        {
            if (!value)
            {
                throw new DomainException(mensage);
            }
        }

        public static void ValidateIsTrue(bool value, string mensage)
        {
            if (value)
            {
                throw new DomainException(mensage);
            }
        }

    }
}
