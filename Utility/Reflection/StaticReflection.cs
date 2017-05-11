namespace RMS.Utility
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public static class StaticReflection
    {
        public static MethodInfo GetMethodInfo(Expression<Action> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }

        public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression)
        {
            return GetMethodInfo((LambdaExpression)expression);
        }

        private static MethodInfo GetMethodInfo(LambdaExpression lambda)
        {
            GuardProperExpressionForm(lambda);
            var call = (MethodCallExpression)lambda.Body;

            return call.Method;
        }

        public static MethodInfo GetPropertyGetMethodInfo<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            PropertyInfo property = GetPropertyInfo<T, TProperty>((LambdaExpression)expression);

            MethodInfo getMethod = property.GetGetMethod();

            if(getMethod == null)
            {
                throw new InvalidOperationException("无效的表达式格式");
            }

            return getMethod;
        }


        public static MethodInfo GetPropertySetMethodInfo<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            PropertyInfo property = GetPropertyInfo<T, TProperty>((LambdaExpression)expression);

            MethodInfo setMethod = property.GetSetMethod();

            if(setMethod == null)
            {
                throw new InvalidOperationException("无效的表达式格式");
            }

            return setMethod;
        }

        private static PropertyInfo GetPropertyInfo<T, TProperty>(LambdaExpression lambda)
        {
            var body = lambda.Body as MemberExpression;
            if(body == null)
            {
                throw new InvalidOperationException("无效的表达式格式");
            }

            var property = body.Member as PropertyInfo;
            if(property == null)
            {
                throw new InvalidOperationException("无效的表达式格式");
            }

            return property;
        }

        public static MemberInfo GetMemberInfo<T, TProperty>(Expression<Func<T, TProperty>> expression)
        {
            expression.NotNull("expression");

            var body = expression.Body as MemberExpression;
            if(body == null)
            {
                throw new InvalidOperationException("无效的表达式格式");
            }

            var member = body.Member as MemberInfo;
            if(member == null)
            {
                throw new InvalidOperationException("无效的表达式格式");
            }

            return member;
        }

        public static ConstructorInfo GetConstructorInfo<T>(Expression<Func<T>> expression)
        {
            expression.NotNull("expression");

            NewExpression body = expression.Body as NewExpression;
            if(body == null)
            {
                throw new InvalidOperationException("无效的表达式格式");
            }

            return body.Constructor;
        }

        private static void GuardProperExpressionForm(Expression expression)
        {
            if(expression.NodeType != ExpressionType.Call)
            {
                throw new InvalidOperationException("无效的表达式格式!");
            }
        }
    }
}
