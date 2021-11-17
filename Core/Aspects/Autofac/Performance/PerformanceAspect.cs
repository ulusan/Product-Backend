using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Castle.DynamicProxy;
using Core.IoC;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        //Artık bu methodu controller de çağırdığımızda performance aspect araya giricek ve methodun çalışma aralığıı süre olarak bize verecektir.
        //tüm bu işlemleri ayrı aspectler haline getirip istediğimiz methodun tepesinde attribute şeklinde uygulayarak hem okunabilirliği, hem modülariteyi, hem sürdürülebilirliği sağlamış olduk.
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}
