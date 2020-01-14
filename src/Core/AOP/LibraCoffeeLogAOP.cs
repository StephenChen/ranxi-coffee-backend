using System;
using System.Linq;
using Castle.DynamicProxy;

namespace LibraCoffee.Core.AOP
{
    /// <summary>
    /// 拦截器 LibraCoffeeLogAOP
    /// </summary>
    public class LibraCoffeeLogAOP : IInterceptor
    {
        /// <summary>
        /// 实例化 IInterceptor
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            // 事前处理: 在服务方法执行之前，做相应的逻辑处理
            var dataIntercept = "" +
                $"[当前执行方法]: {invocation.Method.Name} \r\n" +
                $"[携带的参数有]: {string.Join(',', invocation.Arguments.Select(s => (s ?? "").ToString()))} \r\n";

            try
            {
                // 执行当前访问的服务方法(注意: 如果下边还有其他AOP拦截器，会跳转到其他AOP)
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                dataIntercept += ($"方法执行中出现异常：{ex.Message + ex.InnerException}\r\n");
            }

            // 事后处理: 在 service 被执行之后，做相应的处理，这里输出到控制台
            dataIntercept += $"[执行完成结果]: {invocation.ReturnValue}";

            // 输出到控制台
            Console.WriteLine(dataIntercept);
        }
    }
}