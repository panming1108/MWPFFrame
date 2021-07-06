﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

namespace MWPFFrame.UIControls.Standard
{
    internal static class Verify
    {
        [DebuggerStepThrough]
        public static void IsApartmentState(ApartmentState requiredState, string message)
        {
            if (Thread.CurrentThread.GetApartmentState() != requiredState)
            {
                throw new InvalidOperationException(message);
            }
        }

        [DebuggerStepThrough]
        public static void IsNeitherNullNorEmpty(string value, string name)
        {
            if (null == value)
            {
                throw new ArgumentNullException(name, "The parameter can not be either null or empty.");
            }
            if ("" == value)
            {
                throw new ArgumentException("The parameter can not be either null or empty.", name);
            }
        }

        [DebuggerStepThrough]
        public static void IsNeitherNullNorWhitespace(string value, string name)
        {
            if (null == value)
            {
                throw new ArgumentNullException(name, "The parameter can not be either null or empty or consist only of white space characters.");
            }
            if ("" == value.Trim())
            {
                throw new ArgumentException("The parameter can not be either null or empty or consist only of white space characters.", name);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotDefault<T>(T obj, string name) where T : struct
        {
            if (default(T).Equals(obj))
            {
                throw new ArgumentException("The parameter must not be the default value.", name);
            }
        }

        [DebuggerStepThrough]
        public static void IsNotNull<T>(T obj, string name) where T : class
        {
            if (null == obj)
            {
                throw new ArgumentNullException(name);
            }
        }

        [DebuggerStepThrough]
        public static void IsNull<T>(T obj, string name) where T : class
        {
            if (null != obj)
            {
                throw new ArgumentException("The parameter must be null.", name);
            }
        }

        [DebuggerStepThrough]
        public static void PropertyIsNotNull<T>(T obj, string name) where T : class
        {
            if (null == obj)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The property {0} cannot be null at this time.", name));
            }
        }

        [DebuggerStepThrough]
        public static void PropertyIsNull<T>(T obj, string name) where T : class
        {
            if (null != obj)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "The property {0} must be null at this time.", name));
            }
        }

        [DebuggerStepThrough]
        public static void IsTrue(bool statement, string name)
        {
            if (!statement)
            {
                throw new ArgumentException("", name);
            }
        }

        [DebuggerStepThrough]
        public static void IsTrue(bool statement, string name, string message)
        {
            if (!statement)
            {
                throw new ArgumentException(message, name);
            }
        }

        [DebuggerStepThrough]
        public static void AreEqual<T>(T expected, T actual, string parameterName, string message)
        {
            if (null == (object)expected)
            {
                if (!(actual?.Equals(expected) ?? true))
                {
                    throw new ArgumentException(message, parameterName);
                }
            }
            else if (!expected.Equals(actual))
            {
                throw new ArgumentException(message, parameterName);
            }
        }

        [DebuggerStepThrough]
        public static void AreNotEqual<T>(T notExpected, T actual, string parameterName, string message)
        {
            if (null == (object)notExpected)
            {
                if (actual == null || actual.Equals(notExpected))
                {
                    throw new ArgumentException(message, parameterName);
                }
            }
            else if (notExpected.Equals(actual))
            {
                throw new ArgumentException(message, parameterName);
            }
        }

        [DebuggerStepThrough]
        public static void UriIsAbsolute(Uri uri, string parameterName)
        {
            IsNotNull(uri, parameterName);
            if (!uri.IsAbsoluteUri)
            {
                throw new ArgumentException("The URI must be absolute.", parameterName);
            }
        }

        [DebuggerStepThrough]
        public static void BoundedInteger(int lowerBoundInclusive, int value, int upperBoundExclusive, string parameterName)
        {
            if (value < lowerBoundInclusive || value >= upperBoundExclusive)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The integer value must be bounded with [{0}, {1})", lowerBoundInclusive, upperBoundExclusive), parameterName);
            }
        }

        [DebuggerStepThrough]
        public static void BoundedDoubleInc(double lowerBoundInclusive, double value, double upperBoundInclusive, string message, string parameter)
        {
            if (value < lowerBoundInclusive || value > upperBoundInclusive)
            {
                throw new ArgumentException(message, parameter);
            }
        }

        [DebuggerStepThrough]
        public static void TypeSupportsInterface(Type type, Type interfaceType, string parameterName)
        {
            IsNotNull(type, "type");
            IsNotNull(interfaceType, "interfaceType");
            if (type.GetInterface(interfaceType.Name) == null)
            {
                throw new ArgumentException("The type of this parameter does not support a required interface", parameterName);
            }
        }

        [DebuggerStepThrough]
        public static void FileExists(string filePath, string parameterName)
        {
            IsNeitherNullNorEmpty(filePath, parameterName);
            if (!File.Exists(filePath))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "No file exists at \"{0}\"", filePath), parameterName);
            }
        }

        [DebuggerStepThrough]
        internal static void ImplementsInterface(object parameter, Type interfaceType, string parameterName)
        {
            bool flag = false;
            Type[] interfaces = parameter.GetType().GetInterfaces();
            foreach (Type type in interfaces)
            {
                if (type == interfaceType)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The parameter must implement interface {0}.", interfaceType.ToString()), parameterName);
            }
        }
    }
}
