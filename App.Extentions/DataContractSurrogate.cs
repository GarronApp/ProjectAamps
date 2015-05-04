using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace App.Extentions
{
    [DebuggerStepThrough]
    public class DataContractSurrogate : IDataContractSurrogate
    {
        #region IDataContractSurrogate Members

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }

        public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }

        public Type GetDataContractType(Type type)
        {
            return type;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            if (obj is Array && targetType.IsGenericType)
            {
                var typeArgument = targetType.GetGenericArguments()[0];
                var type = typeof(List<>).MakeGenericType(typeArgument);
                return Activator.CreateInstance(type, obj);
            }

            return obj;
        }

        public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
        {

        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is Array && targetType.IsGenericType)
            {
                var typeArgument = targetType.GetGenericArguments()[0];
                var type = typeof(List<>).MakeGenericType(typeArgument);
                return Activator.CreateInstance(type, obj);
            }

            return obj;
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }

        #endregion
    }
}
