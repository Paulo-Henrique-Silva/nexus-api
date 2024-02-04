using System.ComponentModel;
using System.Reflection;

namespace NexusAPI.Compartilhado.EntidadesBase.Objetos
{
    public static class NexusManipulacaoEnum
    {
        /// <summary>
        /// Obtém o valor do atributo de "Description" do enum, caso não tenha retona o valor do enum.
        /// </summary>
        /// <param name="GenericEnum"></param>
        /// <returns></returns>
        public static string ObterDescricao(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (_Attribs != null && _Attribs.Count() > 0)
                {
                    return ((DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }

            return GenericEnum.ToString();
        }
    }
}
