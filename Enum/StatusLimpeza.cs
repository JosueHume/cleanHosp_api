using System.ComponentModel;

namespace CleanHosp_API.Enum
{
    public enum StatusLimpeza
    {
        [Description("A Realizar")]
        ARealizar = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluído = 3,
    }
}
