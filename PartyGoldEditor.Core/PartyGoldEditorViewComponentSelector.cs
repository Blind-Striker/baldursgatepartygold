using System;
using System.Collections;
using System.Reflection;
using System.Waf.Applications;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;

namespace MvpVmSample.Presentation.PartyGoldEditor.Core
{
    public class PartyGoldEditorViewComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override Type GetComponentType(MethodInfo method, object[] arguments)
        {
            int genericLength = method.GetGenericArguments().Length;

            if (genericLength == 1)
            {
                bool isView =  typeof (IView).IsAssignableFrom(method.GetGenericArguments()[0]);

                if (method.Name == "CreatePresenter" && isView)
                {
                    return method.GetGenericArguments()[0];
                }
            }

            return base.GetComponentType(method, arguments);
        }

        protected override Func<IKernelInternal, IReleasePolicy, object> BuildFactoryComponent(MethodInfo method, string componentName, Type componentType, IDictionary additionalArguments)
        {
            return base.BuildFactoryComponent(method, componentName, componentType, additionalArguments);
        }
    }
}