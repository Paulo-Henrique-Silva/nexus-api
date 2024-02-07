using System.ComponentModel;

namespace NexusAPI.Dados.Enums
{
    public enum TipoEquipamento
    {
        [Description("Memória RAM")]
        MemoriaRAM,

        [Description("Mouse")]
        Mouse,

        [Description("Teclado")]
        Teclado,

        [Description("Processador")]
        Processador,

        [Description("Disco Rígido")]
        DiscoRigido,

        [Description("Placa de Vídeo")]
        PlacaDeVideo,

        [Description("Fonte de Alimentação")]
        FonteDeAlimentacao,

        [Description("Gabinete")]
        Gabinete,

        [Description("Webcam")]
        Webcam,

        [Description("Headset")]
        Headset
    }
}
