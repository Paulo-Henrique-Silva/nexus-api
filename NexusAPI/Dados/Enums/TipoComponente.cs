using System.ComponentModel;

namespace NexusAPI.Dados.Enums
{
    public enum TipoComponente
    {
        [Description("Computador")]
        Computador,

        [Description("Roteador")]
        Roteador,

        [Description("Access Point")]
        AccessPoint,

        [Description("Impressora")]
        Impressora,

        [Description("Switch")]
        Switch,

        [Description("Servidor")]
        Servidor,

        [Description("Modem")]
        Modem,

        [Description("Firewall")]
        Firewall
    }
}
